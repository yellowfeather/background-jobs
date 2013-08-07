namespace Shared.Tests
{
    using Shared.Messaging;

    public class DummyMessageHandler : IMessageHandler<DummyMessage>
    {
        public DummyMessageHandler()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Handle(DummyMessage message)
        {
            this.Count++;
        }
    }
}