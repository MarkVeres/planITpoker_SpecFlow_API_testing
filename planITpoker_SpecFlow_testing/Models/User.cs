using System;
using System.Collections.Generic;
using System.Text;

namespace planITpoker_SpecFlow_testing.Models
{
    public class User
    {
        public User[] players { get; set; }    //this gives the list of players
        public string name { get; set; }       //this is for getting the name of the user
        public bool voted { get; set; }        //this is for seeing if the user has voted
        public bool gameStarted { get; set; }
        public bool closed { get; set; }       //this is for Finish voting
        public int? vote { get; set; }        //this is for the value of the vote
        public int id { get; set; }    //this is the player's ID
        public int? inGameRole { get; set; }   //apparently, "5" is the role of Observer and "6" is the role of Moderator
                                               //player role is "2"
    }
}
