using Pub_Sub_Example_Implementation.Arguments;
using System;

namespace Pub_Sub_Example_Implementation.Publishers
{
    public class GenericPublisher
    {
        EventAggregator EventAggregator;
        public GenericPublisher(EventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public void PublishMessage<T>(T Message) where T : class
        {
            EventAggregator.Publish(Message);
        }
    }

}
