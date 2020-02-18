using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace planITpoker_SpecFlow_testing.Context
{
    public class LoginContext
    {
        public string cookie { get; set; }
        public int gameId { get; set; }
        public string gameCode { get; set; }
    }
}
