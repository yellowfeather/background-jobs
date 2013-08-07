// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinarySerializer.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the BinarySerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// The binary serializer.
    /// </summary>
    public class BinarySerializer : ISerializer
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
        /// The <see cref="byte"/> array.
        /// </returns>
        public byte[] MessageToBytes<T>(T message) where T : class
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var formatter = new BinaryFormatter();
            byte[] messageBody;

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, message);
                messageBody = stream.GetBuffer();
            }

            return messageBody;
        }

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
        /// The <see cref="T"/> message.
        /// </returns>
        public T BytesToMessage<T>(byte[] bytes) where T : class
        {
            return (T)this.BytesToMessage(bytes);
        }

        /// <summary>
        /// The bytes to message.
        /// </summary>
        /// <param name="bytes">
        /// The bytes.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the bytes argument is null.
        /// </exception>
        public object BytesToMessage(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}