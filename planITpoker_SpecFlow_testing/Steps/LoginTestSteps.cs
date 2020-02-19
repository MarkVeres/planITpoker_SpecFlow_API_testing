using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Methods;
using RestSharp;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing
{
    [Binding]
    public class LoginTestSteps
    {
        public LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        public Room room;
        
        public LoginTestSteps(LoginContext loginContext)
        {
            this.loginContext = loginContext;
        }

        [Given(@"I logged in by Quick Play as ""(.*)""")]
        public void GivenILoggedInByQuickPlayAs(string userName)
        {
            var login = new Authentication(client, loginContext);
            login.QuickPlayLogin(userName);
        }

        [Given(@"I create an account using the following credentials ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenICreateAnAccountUsingTheFollowingCredentials(string email, string name, string password)
        {
            var login = new Authentication(client, loginContext);
            login.SignUpLogin(email, name, password);
        }

        [Given(@"I logged in using the following credentials ""(.*)"", ""(.*)""")]
        public void GivenILoggedInUsingTheFollowingCredentials(string email, string password)
        {
            var login = new Authentication(client, loginContext);
            login.LoginLogin(email, password);
        }

        [Given(@"I created a Game Room named ""(.*)""")]
        public void GivenICreatedAGameRoomNamed(string roomName)
        {
            var room = new Games(loginContext, client);
            room.CreateRoom(roomName);
        }
        
        [When(@"I request Game Room information")]
        public void WhenIRequestGameRoomInformation()
        {
            var game = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            room = game.GetRoomInfo();
        }
        
        [Then(@"The name of the Game Room should be ""(.*)""")]
        public void ThenTheNameOfTheGameRoomShouldBe(string roomTitle)
        {
            Assert.Equal(roomTitle, room.title);
        }
    }
}
