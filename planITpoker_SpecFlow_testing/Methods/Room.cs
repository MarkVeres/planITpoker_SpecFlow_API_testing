using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace planITpoker_SpecFlow_testing.Methods
{
    public class Room
    {
        public string title { get; set; }      //this is the Room title
        public bool haveStories { get; set; }   //does the room allow story creation?
        public bool confirmSkip { get; set; }   //do you have to confirm skipping stories?
        public bool showVotingToObservers { get; set; }   //can the observer see the votes?
        public bool autoReveal { get; set; }  //automatically reveal the votes when voting finishes?
        public bool changeVote { get; set; }   //allow players to change vote after they have voted?
        public bool countdownTimer { get; set; }  //use a countdown timer?
        public bool moderatorConnected { get; set; }   //is the moderator connected?

        public void CheckRoomName(string name)
        {
            Assert.Equal(name, this.title);
        }
    }
}
