// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bus.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Bus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    using System;

    using Castle.Windsor;

    using RabbitMQ.Client.MessagePatterns;

    /// <summary>
    /// The bus.
    /// </summary>
    public class Bus : IBus
    {
        /// <summary>
        /// The connection factory.
        /// </summary>
        private readonly IConnectionFactory connectionFactory;

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly ISerializer serializer;

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initialises a new instance of the <see cref="Bus"/> class.
        /// </summary>
        /// <param name="connectionFactory">
        /// The connection factory.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <param name="container">
        /// The IoC container.
        /// </param>
        public Bus(IConnectionFactory connectionFactory, ISerializer serializer, IWindsorContainer container)
        {
            this.connectionFactory = connectionFactory;
            this.serializer = serializer;
            this.container = container;
        }

        /// <summary>
        /// The publish.
        /// </summary>
        /// <param name="queueName">
        /// The queue name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T"> 
        /// The type of the message to publish.
        /// </typeparam>
        public void Publish<T>(string queueName, T message) where T : class
        {
            // Open up a connection and a channel (a connection may have many channels)
            // Note, don't share channels between threads
            using (var connection = this.connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var bytes = this.serializer.MessageToBytes(message);

                // ensure that the queue exists before we publish to it
                channel.QueueDeclare(queueName, false, false, false, null);

                // publish to the "default exchange", with the queue name as the routing key
                channel.BasicPublish(string.Empty, queueName, null, bytes);
            }
        }

        /// <summary>
        /// The subscribe.
        /// </summary>
        /// <param name="queueName">
        /// The queue name.
        /// </param>
        public void Subscribe(string queueName)
        {
            using (var connection = this.connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // ensure that the queue exists before we access it
                channel.QueueDeclare(queueName, false, false, false, null);

                // subscribe to the queue
                var subscription = new Subscription(channel, queueName);
                while (true)
                {
                    // this will block until a messages has landed in the queue
                    var eventArgs = subscription.Next();

                    // deserialize the message body
                    var message = this.serializer.BytesToMessage(eventArgs.Body);
                    var messageType = message.GetType();

                    var handlers = this.GetHandlersForMessageType(messageType);
                    if (handlers.Length == 0)
                    {
                        throw new InvalidOperationException("No handlers were found for message type " + messageType.FullName);
                    }

                    foreach (var handler in handlers)
                    {
                        InvokeHandler(handler, message);
                    }

                    // ack the message, ie. confirm that we have processed it
                    // otherwise it will be requeued a bit later
                    subscription.Ack(eventArgs);
                }
            }
        }

        /// <summary>
        /// Invokes the message handler.
        /// </summary>
        /// <param name="handler">
        /// The handler.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        protected static void InvokeHandler(object handler, object message)
        {
            var method = handler.GetType().GetMethod("Handle");
            method.Invoke(handler, new[] { message });
        }

        /// <summary>
        /// Gets the handlers for the specified message type.
        /// </summary>
        /// <param name="messageType">
        /// The message type.
        /// </param>
        /// <returns>
        /// The <see cref="Array"/> of handlers.
        /// </returns>
        protected Array GetHandlersForMessageType(Type messageType)
        {
            var genericHandlerType = typeof(IMessageHandler<>);
            var handlerType = genericHandlerType.MakeGenericType(messageType);
            var handlers = this.container.ResolveAll(handlerType);
            return handlers;
        }
    }
}