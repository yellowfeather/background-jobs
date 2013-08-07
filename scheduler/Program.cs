// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Scheduler
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using CommonServiceLocator.WindsorAdapter;

    using log4net;

    using Microsoft.Practices.ServiceLocation;

    using Quartz;
    using Quartz.Impl;

    using Shared.Messaging;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Logger.Info("Starting up...");

            var container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container))
                .Install(FromAssembly.This())
                .Install(FromAssembly.Containing<IBus>());
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();

            var job = JobBuilder.Create<SampleJob>().Build();

            var trigger = TriggerBuilder.Create()
                .WithCronSchedule("0 0/5 * * * ?")
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
