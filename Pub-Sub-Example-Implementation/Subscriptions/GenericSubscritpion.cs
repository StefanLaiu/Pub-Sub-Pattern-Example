namespace Pub_Sub_Example_Implementation.Subscriptions
{
    public class Subscription<Tmessage> : IDisposable
    {
        public Action<Tmessage> Action { get; private set; }
        private readonly EventAggregator EventAggregator;
        private bool isDisposed;
        /// <summary>
        /// A  subscription to events from the EventAggregator class which binds the action applied to the messeges of such events.
        /// </summary>
        /// <param name="action">The action taken uppon a event message.</param>
        /// <param name="eventAggregator">The agregator of the events.</param>
        public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
        {
            Action = action;
            EventAggregator = eventAggregator;
        }

        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }
        /// <summary>
        /// Unsubscribing and dispozing of this subscription.
        /// </summary>
        public void Dispose()
        {
            EventAggregator.UnSbscribe(this);
            isDisposed = true;
        }
    }
}
