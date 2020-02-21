using planITpoker_SpecFlow_testing.API;
using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Methods;
using planITpoker_SpecFlow_testing.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing.Steps
{
    [Binding]
    public class MultipleUsersTestsSteps
    {
        public LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        public User user;

        public MultipleUsersTestsSteps(LoginContext loginContext)
        {
            this.loginContext = loginContext;
        }

        [Given(@"a second user logs into the same Game Room as ""(.*)""")]
        public void GivenASecondUserLogsIntoTheSameGameRoomAs(string userName)
        {
            var login = new Authentication(client, loginContext);
            login.SecondUserQuickPlayLogin(userName);
            var aux = new AuxiliaryAPIs(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            aux.GetInGameRoom();
        }

        [When(@"I ask for players information from getPlayersAndState")]
        public void WhenIAskForPlayersInformationFromGetPlayersAndState()
        {
            var games = new Games(loginContext, client);
            user = games.GetPlayersAndStateInfo();
        }

        [Then(@"I should see that the second user's name is ""(.*)""")]
        public void ThenIShouldSeeThatTheSecondUserSNameIs(string userName)
        {
            Assert.Equal(userName, user.players[1].name);
        }
    }
}
