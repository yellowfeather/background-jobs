// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleJob.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the SampleJob type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Scheduler
{
    using System;

    using log4net;

    using Quartz;

    using Shared.Messages;
    using Shared.Messaging;

    /// <summary>
    /// The sample job.
    /// </summary>
    public class SampleJob : IJob
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SampleJob));

        /// <summary>
        /// The message bus.
        /// </summary>
        private readonly IBus bus;

        /// <summary>
        /// Initialises a new instance of the <see cref="SampleJob"/> class.
        /// </summary>
        /// <param name="bus">
        /// The message bus.
        /// </param>
        public SampleJob(IBus bus)
        {
            this.bus = bus;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public void Execute(IJobExecutionContext context)
        {
            Logger.Info("Executing job...");

            try
            {
                var now = DateTime.UtcNow;
                Logger.InfoFormat("Publish message: {0:u}", now);

                var message = new TestMessage { Timestamp = now };
                this.bus.Publish("queue2", message);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception executing job", ex);
            }

            Logger.Info("Execute job completed");
        }
    }
}