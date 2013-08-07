// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionFactory.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the ConnectionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    using System.Configuration;

    using RabbitMQ.Client;

    /// <summary>
    /// The connection factory.
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// The connection factory.
        /// </summary>
        private readonly RabbitMQ.Client.ConnectionFactory connectionFactory;

        /// <summary>
        /// Initialises a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        public ConnectionFactory()
        {
            this.connectionFactory = new RabbitMQ.Client.ConnectionFactory
            {
                Uri = ConfigurationManager.AppSettings["CLOUDAMQP_URL"]
            };
        }

        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <returns>
        /// The <see cref="IConnection"/>.
        /// </returns>
        public IConnection CreateConnection()
        {
            return this.connectionFactory.CreateConnection();
        }

        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <param name="maxRetries">
        /// The max retries.
        /// </param>
        /// <returns>
        /// The <see cref="IConnection"/>.
        /// </returns>
        public IConnection CreateConnection(int maxRetries)
        {
            return this.connectionFactory.CreateConnection(maxRetries);
        }
    }
}