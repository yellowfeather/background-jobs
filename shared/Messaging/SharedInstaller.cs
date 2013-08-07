// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PptSharedInstaller.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the PptSharedInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Messaging
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// The connection factory installer.
    /// </summary>
    public class SharedInstaller : IWindsorInstaller
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
                Component.For<IConnectionFactory>()
                    .ImplementedBy<ConnectionFactory>()
                    .LifeStyle.Singleton);

            container.Register(
                Component.For<ISerializer>()
                    .ImplementedBy<BinarySerializer>()
                    .LifeStyle.Singleton);

            container.Register(
                Component.For<IBus>()
                    .ImplementedBy<Bus>()
                    .LifeStyle.Transient);
        }
    }
}