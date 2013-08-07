namespace Shared.Tests
{
    using NUnit.Framework;

    using Shared.Messaging;

    [TestFixture]
    public class BusTests
    {
        [Test]
        public void CanInvokeHelper()
        {
            var handler = new DummyMessageHandler();
            var genericHandler = handler as IMessageHandler<DummyMessage>;
            var message = new DummyMessage();
            BusWrapper.InvokeHandlerWrapper(genericHandler, message);

            Assert.AreEqual(1, handler.Count);
        }
    }
}
