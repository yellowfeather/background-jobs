// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Worker
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using log4net;

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
        /// The main.
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

            var bus = container.Resolve<IBus>();
            bus.Subscribe("queue2");

            Logger.Info("Closing down");
        }
    }
}
