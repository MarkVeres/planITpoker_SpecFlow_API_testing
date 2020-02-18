using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace planITpoker_SpecFlow_testing.Models
{
    public class Story
    {
        public Story[] stories { get; set; }
        public string title { get; set; }
        public int GameId { get; set; }
        public int id { get; set; }   //this is the story Id
        public int? estimate { get; set; }
        public bool storiesCreated { get; set; }
        public int? storiesCount { get; set; }
    }
}
