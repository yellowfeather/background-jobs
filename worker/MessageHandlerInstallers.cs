// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageHandlerInstallers.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the MessageHandlerInstallers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Worker
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Shared.Messages;
    using Shared.Messaging;

    /// <summary>
    /// The message handler installers.
    /// </summary>
    public class MessageHandlerInstallers : IWindsorInstaller
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
                Component
                    .For<IMessageHandler<TestMessage>>()
                    .ImplementedBy<TestMessageMessageHandler>());
        }
    }
}