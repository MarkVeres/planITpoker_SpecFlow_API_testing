﻿using System;
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
        public int? inGameRole { get; set; }   //inGameRole parameter changes depending on the order of the users
                                               //example: if the first user is observer he will have the role value "5", 
                                               //if the second user is observer he will have the role value "1"
                                               //always check manually for inGameRole values
    }
}
