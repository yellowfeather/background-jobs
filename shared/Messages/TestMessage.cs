// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMessage.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the TestMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messages
{
    using System;

    /// <summary>
    /// The test message.
    /// </summary>
    [Serializable]
    public class TestMessage
    {
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; } 
    }
}