// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageHandler.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the IMessageHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    /// <summary>
    /// The MessageHandler interface.
    /// </summary>
    /// <typeparam name="T"> The type of the message to handle.
    /// </typeparam>
    public interface IMessageHandler<in T>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Handle(T message);
    }
}