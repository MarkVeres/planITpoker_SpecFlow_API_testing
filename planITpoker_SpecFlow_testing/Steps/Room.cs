using System;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing
{
    [Binding]
    public class Room
    {
        public string title { get; set; }

        [Then(@"The Room name should be ""(.*)""")]
        public void ThenTheRoomNameShouldBe(string roomTitle)
        {
            Assert.Equal(roomTitle, title);
        }
    }
}
