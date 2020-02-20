using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Methods;
using planITpoker_SpecFlow_testing.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace planITpoker_SpecFlow_testing.Steps
{
    [Binding]
    public class RoomCreationTestsSteps
    {
        public LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        public Room room;
        public List<ListRoom> listRoom;

        public RoomCreationTestsSteps(LoginContext loginContext)
        {
            this.loginContext = loginContext;
        }

        [Given(@"I log in by Quick Play as ""(.*)""")]
        public void GivenILogInByQuickPlayAs(string userName)
        {
            var login = new Authentication(client, loginContext);
            login.QuickPlayLogin(userName);
        }

        [Given(@"I create a Game Room named ""(.*)"" that cannot have stories")]
        public void GivenICreateAGameRoomNamedThatCannotHaveStories(string roomName)
        {
            var games = new Games(loginContext, client);
            games.CreateRoomHaveStories(roomName, false);
        }

        [Given(@"I create a Game Room named ""(.*)"" in which skipping stories does not require confirmation")]
        public void GivenICreateAGameRoomNamedInWhichSkippingStoriesDoesNotRequireConfirmation(string roomName)
        {
            var games = new Games(loginContext, client);
            games.CreateRoomSkipConfirmation(roomName, false);
        }

        [Given(@"I create a Game Room named ""(.*)"" in which the observer cannot see the votes during the voting process")]
        public void GivenICreateAGameRoomNamedInWhichTheObserverCannotSeeTheVotesDuringTheVotingProcess(string roomName)
        {
            var games = new Games(loginContext, client);
            games.CreateRoomObserverSeeingVotes(roomName, false);
        }

        [Given(@"I create a Game Room named ""(.*)"" that automatically reveals votes at the end of the voting process")]
        public void GivenICreateAGameRoomNamedThatAutomaticallyRevealsVotesAtTheEndOfTheVotingProcess(string roomName)
        {
            var games = new Games(loginContext, client);
            games.CreateRoomAutoVoteReveal(roomName, true);
        }

        [Given(@"I create a Game Room named ""(.*)"" in which changing votes is permitted")]
        public void GivenICreateAGameRoomNamedInWhichChangingVotesIsPermitted(string roomName)
        {
            var games = new Games(loginContext, client);
            games.CreateRoomAllowChangeVote(roomName, true);
        }

        [Given(@"I create a Game Room named ""(.*)"" that uses a countdowntimer")]
        public void GivenICreateAGameRoomNamedThatUsesACountdowntimer(string roomName)
        {
            var games = new Games(loginContext, client);
            games.UseCountDownTimer(roomName, true, 30);
        }

        [Given(@"I reset the Game Room")]
        public void GivenIResetTheGameRoom()
        {
            var reset = new Games(loginContext, client);
            reset.ResetGameRoom();
        }

        [Given(@"I modify Game Room setting by adding a countdown timer")]
        public void GivenIModifyGameRoomSettingByAddingACountdownTimer()
        {
            var modify = new Games(loginContext, client);
            modify.EditCreatedGameRoom("Test Room", true, 30);
        }

        [Given(@"I delete the Game Room")]
        public void GivenIDeleteTheGameRoom()
        {
            var delete = new Games(loginContext, client);
            delete.DeleteGameRoom();
        }

        [When(@"I request information regarding the Game Room")]
        public void WhenIRequestInformationRegardingTheGameRoom()
        {
            var game = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            room = game.GetRoomInfo();
        }


        [When(@"I request Room List information")]
        public void WhenIRequestRoomListInformation()
        {
            var list = new Games(loginContext, client);
            listRoom = list.GetGamesListInfo();
        }

        [Then(@"I should see that I am unable to add stories to the Game Room")]
        public void ThenIShouldSeeThatIAmUnableToAddStoriesToTheGameRoom()
        {
            Assert.False(room.haveStories);
        }

        [Then(@"I should see that I do not have to give confirmation for skipping stories")]
        public void ThenIShouldSeeThatIDoNotHaveToGiveConfirmationForSkippingStories()
        {
            Assert.False(room.confirmSkip);
        }

        [Then(@"I should see that the observer is unable to see the votes during the voting process")]
        public void ThenIShouldSeeThatTheObserverIsUnableToSeeTheVotesDuringTheVotingProcess()
        {
            Assert.False(room.showVotingToObservers);
        }

        [Then(@"I should see that the votes will be revealed automatically")]
        public void ThenIShouldSeeThatTheVotesWillBeRevealedAutomatically()
        {
            Assert.True(room.autoReveal);
        }

        [Then(@"I should see that changing votes, after voting, is permitted")]
        public void ThenIShouldSeeThatChangingVotesAfterVotingIsPermitted()
        {
            Assert.True(room.changeVote);
        }

        [Then(@"I should see that the Game Room has a countdowntimer")]
        public void ThenIShouldSeeThatTheGameRoomHasACountdowntimer()
        {
            Assert.True(room.countdownTimer);
        }

        [Then(@"I should see that now, my Room has a countdown timer")]
        public void ThenIShouldSeeThatNowMyRoomHasACountdownTimer()
        {
            Assert.True(listRoom[0].countdownTimer);
        }

        [Then(@"I should see that the Game Room does not exist")]
        public void ThenIShouldSeeThatTheGameRoomNamedDoesNotExist()
        {
            Assert.Null(listRoom[0].name);
        }
    }
}
