using Microsoft.AspNetCore.Routing;
using Pub_Sub_Example_Implementation;
using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Publishers;
using Pub_Sub_Example_Implementation.Subscribers;

namespace Pub_Sub_Test
{
    public class PubSubIntegrationTest
    {
        private static readonly int[] intField = { 45 };
        private static readonly string stringField = "Where am I?!";
        protected bool fisrtSubRezult = false;
        protected bool secondSubRezult = false;
        [Fact]
        public void TestPubSub()
        {
            //Arrange
            EventAggregator _eventH = new();
            GenericPublisher pub = new(_eventH);
            GenericSubscriber<Array> subInt = new(_eventH);
            GenericSubscriber<string> subText = new(_eventH);
            _eventH.Subscribe<int[]>(CompareToLocalArrayFields);
            _eventH.Subscribe<string>(ComparetoLocalStringFields);

            //Act
            pub.PublishMessage(new int[] { 45});
            pub.PublishMessage("What Am I");

            //Assert
            Assert.True(fisrtSubRezult);
            Assert.False(secondSubRezult);
        }
        private void CompareToLocalArrayFields(int[] input)
        {
            fisrtSubRezult= input[0] == intField[0];
        }

        private void ComparetoLocalStringFields(string input)
        {
            secondSubRezult = input.Equals(stringField);
        }
    }
}
   
