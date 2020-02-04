using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing
{
    [Binding]
    public class Room
    {
        public string title { get; set; }

        [Then(@"The Room name should be ""(.*)""")]
        public void RoomName(string p0)
        {
            Assert.Equal(p0, title);
        }
    }
}
