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
        public CurrentStory currentStory;
        private string initialTimer, secondTimer;
        public string gameReport;

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
            var games = new Games(loginContext, client, loginContext.cookie);
            games.CreateRoom(roomName);
        }

        [Given(@"I change my role to observer")]
        public void GivenIChangeMyRoleToObserver()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            games.GetFirstUserId();
            games.ChangeRoleModeratorToObserver();
        }

        [Given(@"I create a story named ""(.*)""")]
        public void GivenICreateAStoryNamed(string storyName)
        {
            stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.CreateStory(storyName);
        }

        [Given(@"I change the title of the story to ""(.*)""")]
        public void GivenIChangeTheTitleOfTheStoryTo(string newStoryTitle)
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.GetStoryEditInfo();
            stories.UpdateStoryName(newStoryTitle);
        }

        [Given(@"I start the game")]
        public void GivenIStartTheGame()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.StartGame();
        }

        [Given(@"I vote")]
        public void GivenIVote()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.Vote();
        }

        [Given(@"I clear the votes")]
        public void GivenIClearTheVotes()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            games.ClearVotes();
        }

        [Given(@"I skip the current story")]
        public void GivenISkipTheCurrentStory()
        {
            stories.SkipStory();
            stories.StartGame();
        }

        [Given(@"I Finish voting")]
        public void GivenIFinishVoting()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.FinishVoting();
        }

        [Given(@"I reveal the cards")]
        public void GivenIRevealTheCards()
        {
            stories.RevealCards();
        }

        [Given(@"I set the initial timer")]
        public void GivenISetTheInitialTimer()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            var timer = games.GetCurrentStoryInfo();
            initialTimer = timer.GetVotingStart();
        }

        [Given(@"I reset the Game Timer")]
        public void GivenIResetTheGameTimer()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            games.ResetTimer();
        }

        [When(@"I set the second Timer")]
        public void WhenISetTheSecondTimer()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            var timer = games.GetCurrentStoryInfo();
            secondTimer = timer.GetVotingStart();
        }

        [Given(@"I delete a story")]
        public void GivenIDeleteAStory()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.GetStoryEditInfo();
            stories.DeleteStory();
        }

        [Given(@"I change my estimate")]
        public void GivenIChangeMyEstimate()
        {
            var changeEstimate = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            changeEstimate.GetStoryEstimateEditInfo();
            changeEstimate.UpdateStoryEstimate(5);
        }

        [When(@"I request information from getStoryState")]
        public void WhenIRequestInformationFromGetStoryState()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            story = games.GetStoryState();
        }

        [When(@"I request story information")]
        public void WhenIRequestStoryInformation()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            story = stories.GetStoryInformation();
        }

        [When(@"I request Current Story Information")]
        public void WhenIRequestCurrentStoryInformation()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            currentStory = games.GetCurrentStoryInfo();
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
            var games = new Games(loginContext, client, loginContext.cookie);
            user = games.GetPlayersAndStateInfo();
        }

        [When(@"I request Vote information")]
        public void WhenIRequestVoteInformation()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            user = games.GetVoteInformation();
        }

        [When(@"I request story estimate information")]
        public void WhenIRequestStoryEstimateInformation()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            story = stories.GetStoryEstimateInfo();
        }

        [When(@"I generate a report of the Game")]
        public void WhenIGenerateAReportOfTheGame()
        {
            var aux = new AuxiliaryAPIs(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            aux.ExportStories();
            gameReport = aux.GetExportInfo();
        }

        [When(@"I request player information from getPlayInfo")]
        public void WhenIRequestPlayerInformationFromGetPlayInfo()
        {
            var play = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            user = play.GetPlayerInfo();
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

        [Then(@"I should see that the voting step has ended")]
        public void ThenIShouldSeeThatTheVotingHasFinished()
        {
            Assert.True(user.closed);
        }

        [Then(@"I should see that my estimate is (.*)")]
        public void ThenIShouldSeeThatMyEstimateIs(int num)
        {
            Assert.Equal(num, story.stories[0].estimate);
        }

        [Then(@"I Should see that the Current Story is named ""(.*)""")]
        public void ThenIShouldSeeThatTheCurrentStoryIsNamed(string storyTitle)
        {
            Assert.Equal(storyTitle, currentStory.title);
        }

        [Then(@"I should see that my vote has been cleared")]
        public void ThenIShouldSeeThatMyVoteHasBeenCleared()
        {
            Assert.False(user.players[0].voted);
        }

        [Then(@"I Should see that the vote value is (.*)")]
        public void ThenIShouldSeeThatTheVoteValuesIs(int voteValue)
        {
            Assert.Equal(-1, user.players[0].vote);
        }

        [Then(@"I should see that the ""(.*)"" is in the story list")]
        public void ThenIShouldSeeThatTheIsInTheStoryList(string storyName)
        {
            Assert.Equal(storyName, story.stories[1].title);
        }

        [Then(@"I should see that the two timers are different")]
        public void ThenIShouldSeeThatTheTwoTimersAreDifferent()
        {
            Assert.True(initialTimer != secondTimer);
        }

        [Then(@"I should see that there are no stories created")]
        public void ThenIShouldSeeThatThereAreNoStoriesCreated()   //BUG FOUND! moderator can create a story in a room that does not allow story creation
        {
            //Assert.False(room.haveStories);   //this assert passes which means the room does not allow story creation
            //however, it seems that through API calls, a moderator can add stories even though the room does not allow it
            Assert.False(story.storiesCreated);
        }

        [Then(@"I should see that my estimate has changed")]
        public void ThenIShouldSeeThatMyEstimateHasChanged()
        {
            Assert.Equal(5, story.stories[0].estimate);
        }

        [Then(@"I should see the user name ""(.*)"" and the story title ""(.*)"" within that report")]
        public void ThenIShouldSeeTheUserNameAndTheRoomNameWithinThatReport(string userName, string storyTitle)
        {
            Assert.Contains(userName, gameReport);
            Assert.Contains(storyTitle, gameReport);
        }

        [Then(@"I should see that the game has not started")]
        public void ThenIShouldSeeThatTheGameHasNotStarted()
        {
            Assert.False(room.gameStarted);
        }

        [Then(@"I should see that there are no votes submitted")]
        public void ThenIShouldSeeThatIHaveNotVoted()
        {
            Assert.Null(room.votes);
        }        

        [Then(@"I should see that my vote is still null")]
        public void ThenIShouldSeeThatMyVoteIsStillNull()  //BUG FOUND !
        {
            Assert.Null(user.players[0].vote);
            //Moderator tries to vote while in the role of observer bug; observer should not be able to vote but is able
        }

        [Then(@"I should see that the voting had not been ended")]
        public void ThenIShouldSeeThatTheVotingHadNotBeenEnded()
        {
            Assert.False(user.closed);
        }

        [Then(@"I should see that my estimate is null")]
        public void ThenIShouldSeeThatMyEstimateIsNull()
        {
            Assert.Null(story.stories[0].estimate);
        }

        [Then(@"I Should see that the vote value is not (.*)")]
        public void ThenIShouldSeeThatTheVoteValueIsNot(int p0)
        {
            Assert.False(-1 == user.players[0].vote);
        }

        [Then(@"I should see that my role has been changed to observer")]
        public void ThenIShouldSeeThatMyRoleHasBeenChangedToObserver()
        {
            Assert.Equal(5, user.players[0].inGameRole);
        }
    }
}
