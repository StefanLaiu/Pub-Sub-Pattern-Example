using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Subscriptions;

namespace Pub_Sub_Example_Implementation.Subscribers
{
   /// <summary>
   /// A subscripber to events from the EventAggregator class.
   /// Should be used only when the simple listing of messages is needed. If aditional logic needs to be applied to the messages a direct subscription to the event aggregator is recomended!
   /// </summary>
   /// <typeparam name="T">The type of the messages to witch it subscribes.</typeparam>
    public class GenericSubscriber<T> where T : class
    {
        public List<T> Messages = new ();
        Subscription<T> Subscription;
        private readonly EventAggregator eventAggregator;

        public GenericSubscriber(EventAggregator eve)
        {
            eventAggregator = eve;
            Subscription = eve.Subscribe<T>(ReturnToDisplay);
        }

        private void ReturnToDisplay(T message)
        {
            Messages.Add(message);
        }
        public void Unsubscribe()
        {
            eventAggregator.UnSbscribe(Subscription);
        }
    }
}
