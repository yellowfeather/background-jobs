// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the ISerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    /// <summary>
    /// The serializer interface.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// The message to bytes.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// The type of the message to convert to bytes.
        /// </typeparam>
        /// <returns>
        /// The <see cref="byte" /> array.
        /// </returns>
        byte[] MessageToBytes<T>(T message) where T : class;

        /// <summary>
        /// The bytes to message.
        /// </summary>
        /// <param name="bytes">
        /// The bytes.
        /// </param>
        /// <typeparam name="T">
        /// The type of the message to return.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T BytesToMessage<T>(byte[] bytes) where T : class;

        /// <summary>
        /// The bytes to message.
        /// </summary>
        /// <param name="bytes">
        /// The bytes.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object BytesToMessage(byte[] bytes);
    }
}