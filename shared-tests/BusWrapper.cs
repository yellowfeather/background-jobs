namespace Shared.Tests
{
    using Castle.Windsor;

    using Shared.Messaging;

    public class BusWrapper : Bus
    {
        public BusWrapper(IConnectionFactory connectionFactory, ISerializer serializer, IWindsorContainer container)
            : base(connectionFactory, serializer, container)
        {
        }

        public static void InvokeHandlerWrapper(object handler, object message)
        {
            InvokeHandler(handler, message);
        }
    }
}