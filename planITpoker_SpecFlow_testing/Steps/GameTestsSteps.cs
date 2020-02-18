using planITpoker_SpecFlow_testing.API;
using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Methods;
using planITpoker_SpecFlow_testing.Models;
using RestSharp;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing.Steps
{
    [Binding]
    public class GameTestsSteps
    {
        public LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        public Story story;
        public Stories stories;
        public Room room;
        public User user;

        public GameTestsSteps(LoginContext loginContext)
        {
            this.loginContext = loginContext;
        }

        [Given(@"I log in via Quick Play as ""(.*)""")]
        public void GivenILogInViaQuickPlayAs(string userName)
        {
            var login = new Authentication(client, loginContext);
            login.QuickPlayLogin(userName);
        }
        
        [Given(@"I create a Game Room named ""(.*)""")]
        public void GivenICreateAGameRoomNamed(string roomName)
        {
            var room = new Games(loginContext, client);
            room.CreateRoom(roomName);
        }
        
        [Given(@"I create a story named ""(.*)""")]
        public void GivenICreateAStoryNamed(string storyName)
        {
            stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.CreateStory(storyName);
        }

        [Given(@"I start the game")]
        public void GivenIStartTheGame()
        {
            stories.StartGame();
        }

        [Given(@"I vote")]
        public void GivenIVote()
        {
            stories.Vote();
        }

        [When(@"I request story information")]
        public void WhenIRequestStoryInformation()
        {
            story = stories.GetStoryInformation();
        }

        [When(@"I request Game information from getPlayInfo")]
        public void WhenIRequestGameInformationFromGetPlayInfo()
        {
            var play = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            room = play.GetPlayInfo();
        }

        [When(@"I request Game information from getPlayersAndState")]
        public void WhenIRequestGameInformationFromGetPlayersAndState()
        {
            var games = new Games(loginContext, client);
            user = games.GetPlayersAndStateInfo();
        }

        [When(@"I request Vote information")]
        public void WhenIRequestVoteInformation()
        {
            var games = new Games(loginContext, client);
            user = games.GetVoteInformation();
        }

        [Then(@"I should see that the story is named ""(.*)""")]
        public void ThenIShouldSeeThatTheStoryIsNamed(string storyName)
        {
            Assert.Equal(storyName, story.stories[0].title);
        }

        [Then(@"I should see that the moderator is connected")]
        public void ThenIShouldSeeThatTheModeratorIsConnected()
        {
            Assert.True(room.moderatorConnected);
        }

        [Then(@"I should see that the game has started")]
        public void ThenIShouldSeeThatTheGameHasStarted()
        {
            Assert.True(user.gameStarted);
        }

        [Then(@"I should see that I have voted")]
        public void ThenIShouldSeeThatIHaveVoted()
        {
            Assert.True(user.players[0].voted);
        }
    }
}
