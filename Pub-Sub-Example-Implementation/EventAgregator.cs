using System.Collections;
using Pub_Sub_Example_Implementation.Subscriptions;

namespace Pub_Sub_Example_Implementation
{
    public class EventAggregator
    {
        private Dictionary<Type, IList> subscriber;
        public EventAggregator()
        {
            subscriber = new Dictionary<Type, IList>();
        }

        public void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            if (subscriber.ContainsKey(t))
            {
                actionlst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());

                foreach (Subscription<TMessageType> a in actionlst)
                {
                    a.Action(message);
                }
            }
        }

        public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            var actiondetail = new Subscription<TMessageType>(action, this);

            if (subscriber.TryGetValue(t, out IList actionlst))
            {
                actionlst.Add(actiondetail);
            }
            else
            {
                actionlst = new List<Subscription<TMessageType>>
                {
                    actiondetail
                };
                subscriber.Add(t, actionlst);
            }

            return actiondetail;
        }

        public void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscriber.ContainsKey(t))
            {
                subscriber[t].Remove(subscription);
            }
        }

    }
}
