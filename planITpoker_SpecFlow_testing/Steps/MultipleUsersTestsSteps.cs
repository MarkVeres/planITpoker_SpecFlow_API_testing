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
        public Story story;
        public Room room;
        public CurrentStory currentStory;
        private string initialTimer, secondTimer;

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

        [Given(@"I remove Jack from the game room")]
        public void GivenIRemoveJackFromTheGameRoom()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            games.GetSecondUserId();
            games.RemovePlayer();
        }

        [Given(@"Jack creates a story named ""(.*)""")]
        public void GivenJackCreatesAStory(string storyTitle)
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.CreateStory(storyTitle);
        }

        [Given(@"Jack tries to start the game")]
        public void GivenJackTriesToStartTheGame()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.StartGame();
        }

        [Given(@"Jack votes")]
        public void GivenJackVotes()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.Vote();
        }

        [Given(@"Jack submits an estimate")]
        public void GivenJackSubmitsAnEstimate()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.FinishVoting();
        }

        [Given(@"Jack tries to skip the current story")]
        public void GivenJackTriesToSkipTheCurrentStory()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.SkipStory();
            stories.StartGame();
        }

        [Given(@"I start the game and set the initial timer")]
        public void GivenIStartTheGameAndSetTheInitialTimer()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            stories.StartGame();
            var games = new Games(loginContext, client, loginContext.cookie);
            var timer = games.GetCurrentStoryInfo();
            initialTimer = timer.GetVotingStart();
        }

        [Given(@"Jack tries to reset the in-game timer")]
        public void GivenJackTriesToResetTheIn_GameTimer()
        {
            var games = new Games(loginContext, client, loginContext.secondUserCookie);
            games.ResetTimer();
        }

        [Given(@"Jack tries to reveal the cards")]
        public void GivenJackTriesToRevealTheCards()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.RevealCards();
        }

        [Given(@"Jack tries to clear the votes")]
        public void GivenJackTriesToClearTheVotes()
        {
            var games = new Games(loginContext, client, loginContext.secondUserCookie);
            games.ClearVotes();            
        }

        [Given(@"Jack tries to end the voting process")]
        public void GivenJackTriesToEndTheVotingProcess()   //this is also used for sending estimates !!!
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.FinishVoting();
        }

        [Given(@"Jack tries to change the title of the story to ""(.*)""")]
        public void GivenJackTriesToChangeTheTitleOfTheStoryTo(string newStoryTitle)
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.secondUserCookie);
            stories.GetStoryEditInfo();
            stories.UpdateStoryName(newStoryTitle);
        }

        [Given(@"I assign Jack as observer")]
        public void GivenIAssignJackAsObserver()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            games.GetSecondUserId();
            games.ChangeRolePlayerToObserver();
        }

        [When(@"I set the second timer")]
        public void WhenISetTheSecondTimer()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            var timer = games.GetCurrentStoryInfo();
            secondTimer = timer.GetVotingStart();
        }

        [When(@"I ask for information from getPlayersAndState")]
        public void WhenIAskForPlayersInformationFromGetPlayersAndState()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            user = games.GetPlayersAndStateInfo();
        }

        [When(@"I ask for Story information")]
        public void WhenIAskForStoryInformation()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            story = stories.GetStoryInformation();
        }

        [When(@"I request Room information from GetPlayInfo")]
        public void WhenIRequestRoomInformation()
        {
            var play = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            room = play.GetPlayInfo();
        }

        [When(@"I request Vote information from GetVoteInfo")]
        public void WhenIRequestVoteInformationFromGetVoteInfo()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            user = games.GetVoteInformation();
        }

        [When(@"I request information about the current story")]
        public void WhenIRequestInformationAboutTheCurrentStory()
        {
            var games = new Games(loginContext, client, loginContext.cookie);
            currentStory = games.GetCurrentStoryInfo();
        }

        [When(@"I request information about story estimates")]
        public void WhenIRequestInformationAboutStoryEstimates()
        {
            var stories = new Stories(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            story = stories.GetStoryEstimateInfo();
        }

        [Then(@"I should see that the second user's name is ""(.*)""")]
        public void ThenIShouldSeeThatTheSecondUserSNameIs(string userName)
        {
            Assert.Equal(userName, user.players[1].name);
        }

        [Then(@"i should see that Jack could not create a story, as there is only (.*) story created")]
        public void ThenIShouldSeeThatJackCouldNotCreateAStoryAsThereIsOnlyStoryCreated(int storyNumber)
        {
            Assert.Equal(storyNumber, story.storiesCount);
        }

        [Then(@"I Should see that Jack was unable to start the game")]
        public void ThenIShouldSeeThatJackWasUnableToStartTheGame()
        {
            Assert.False(room.gameStarted);
        }

        [Then(@"I should see that Jack has voted")]
        public void ThenIShouldSeeThatJackHasVoted()
        {
            Assert.True(user.players[1].voted);
        }

        [Then(@"I should see that the current story is still ""(.*)""")]
        public void ThenIShouldSeeThatTheCurrentStoryIsStill(string storyTitle)
        {
            Assert.Equal(storyTitle, currentStory.title);
        }

        [Then(@"I should see that Jack could not reset the timer, because the two timers are identical")]
        public void ThenIShouldSeeThatJackCouldNotResetTheTimerBecauseTheTwoTimersAreIdentical()
        {
            Assert.True(initialTimer == secondTimer);
        }

        [Then(@"I should see that my vote is null")]
        public void ThenIShouldSeeThatMyVoteIsNull()   //BUG FOUND!  Second User is able to reveal cards after and before game starts
        {
            Assert.Null(user.players[0].vote);
            //since that the first user did not vote; normally his "vote" value should have been null
            //actual vote value is "-1" that means that the second user was able to reveal the cards
        }

        [Then(@"I Should see that my vote has not been cleared")]
        public void ThenIShouldSeeThatMyVoteHasNotBeenCleared()
        {
            Assert.True(user.players[0].voted);
        }

        [Then(@"I should see that the voting process has not ended")]
        public void ThenIShouldSeeThatTheVotingProcessHasNotEnded()
        {
            Assert.False(user.closed);
        }

        [Then(@"I should see that the story name is still ""(.*)""")]
        public void ThenIShouldSeeThatTheStoryNameIsStill(string storyTitle)
        {
            Assert.Equal(storyTitle, story.stories[0].title);
        }

        [Then(@"I should see that Jack has no estimate submitted")]
        public void ThenIShouldSeeThatJackHasNoEstimateSubmitted()
        {
            Assert.Null(story.stories[0].estimate);
        }

        [Then(@"I should see that there are no stories in this room")]
        public void ThenIShouldSeeThatThereAreNoStoriesInThisRoom()
        {
            Assert.False(room.storiesCreated);
        }

        [Then(@"I should see that there is only (.*) user in the room")]
        public void ThenIShouldSeeThatThereIsOnlyUserInTheRoom(int num)
        {
            Assert.Equal(num, room.playersCount);
        }

        [Then(@"I should see that Jack has the role of observer")]
        public void ThenIShouldSeeThatJackHasTheRoleOfObserver()
        {
            Assert.Equal(1, user.players[1].inGameRole);
            //check comments in User.cs for inGameRole disambiguation
        }

        [Then(@"I should see that there are nobody has voted")]
        public void ThenIShouldSeeThatThereAreNobodyHasVoted()
        {
            Assert.Null(room.votes);
        }
    }
}
