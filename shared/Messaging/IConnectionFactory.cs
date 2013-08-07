// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectionFactory.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   The ConnectionFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    using RabbitMQ.Client;

    /// <summary>
    /// The ConnectionFactory interface.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <returns>
        /// The <see cref="IConnection"/>.
        /// </returns>
        IConnection CreateConnection();

        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <param name="maxRetries">
        /// The max retries.
        /// </param>
        /// <returns>
        /// The <see cref="IConnection"/>.
        /// </returns>
        IConnection CreateConnection(int maxRetries);
    }
}