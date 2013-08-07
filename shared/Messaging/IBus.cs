// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBus.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the IBus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    /// <summary>
    /// The Bus interface.
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// The publish.
        /// </summary>
        /// <param name="queueName">
        /// The queue Name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// The type of the message to publish.
        /// </typeparam>
        void Publish<T>(string queueName, T message) where T : class;

        /// <summary>
        /// The subscribe.
        /// </summary>
        /// <param name="queueName">
        /// The queue name.
        /// </param>
        void Subscribe(string queueName);
    }
}