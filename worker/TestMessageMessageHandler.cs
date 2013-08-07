// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMessageMessageHandler.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the TestMessageMessageHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Worker
{
    using log4net;

    using Shared.Messages;
    using Shared.Messaging;

    /// <summary>
    /// The test message message handler.
    /// </summary>
    public class TestMessageMessageHandler : IMessageHandler<TestMessage>
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TestMessageMessageHandler));

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Handle(TestMessage message)
        {
            Logger.InfoFormat("Received TestMessage: Timestamp {0:u}", message.Timestamp);
        }
    }
}