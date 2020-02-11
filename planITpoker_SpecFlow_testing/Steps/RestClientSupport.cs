using BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace planITpoker_SpecFlow_testing.Steps
{
    [Binding]
    public class RestClientSupport
    {
        //private readonly IObjectContainer objectContainer;

        //public RestClientSupport(IObjectContainer objectContainer)
        //{
        //    this.objectContainer = objectContainer;
        //}

        //[BeforeScenario]
        //public LoginStep InitializeWebDriver()
        //{
        //    var client = new RestClient("https://www.planitpoker.com");
        //    objectContainer.RegisterInstanceAs<RestClient>(client);
        //   // return new LoginStep(client);
        //}
    }
}
