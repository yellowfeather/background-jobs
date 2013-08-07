// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobInstaller.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the JobInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Scheduler
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Quartz;

    /// <summary>
    /// The job installer.
    /// </summary>
    public class JobInstaller : IWindsorInstaller
    {
        /// <summary>
        /// The install.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="store">
        /// The store.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IJob>()
                    .ImplementedBy<SampleJob>()
                    .LifestyleTransient());
        }
    }
}