using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Methods;
using RestSharp;
using System;
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
            var room = new Games(loginContext, client);
            room.CreateRoomHaveStories(roomName, false);

            //var body = $"name={roomName}" +
            //    $"&cardSetType=1" +
            //    $"&haveStories=false" +
            //    $"&confirmSkip=true" +
            //    $"&showVotingToObservers=true" +
            //    $"&autoReveal=true" +
            //    $"&changeVote=false" +
            //    $"&countdownTimer=false" +
            //    $"&countdownTimerValue=30";
            //var request = new RestRequest("/api/games/create/", Method.POST);

            //request.AddHeader("Content-Length", body.Length.ToString());
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", cookie);

            //request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            //var response = client.Execute(request);

            //var content = response.Content;
            //var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            //gameId = deserializeObject.gameId;
            //gameCode = deserializeObject.gameCode;
        }

        [Given(@"I create a Game Room named ""(.*)"" in which skipping stories does not require confirmation")]
        public void GivenICreateAGameRoomNamedInWhichSkippingStoriesDoesNotRequireConfirmation(string roomName)
        {
            var room = new Games(loginContext, client);
            room.CreateRoomSkipConfirmation(roomName, false);

            //var body = $"name={roomName}" +
            //    $"&cardSetType=1" +
            //    $"&haveStories=true" +
            //    $"&confirmSkip=false" +
            //    $"&showVotingToObservers=true" +
            //    $"&autoReveal=true" +
            //    $"&changeVote=false" +
            //    $"&countdownTimer=false" +
            //    $"&countdownTimerValue=30";
            //var request = new RestRequest("/api/games/create/", Method.POST);

            //request.AddHeader("Content-Length", body.Length.ToString());
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", cookie);

            //request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            //var response = client.Execute(request);

            //var content = response.Content;
            //var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            //gameId = deserializeObject.gameId;
            //gameCode = deserializeObject.gameCode;
        }

        [Given(@"I create a Game Room named ""(.*)"" in which the observer cannot see the votes during the voting process")]
        public void GivenICreateAGameRoomNamedInWhichTheObserverCannotSeeTheVotesDuringTheVotingProcess(string roomName)
        {
            var room = new Games(loginContext, client);
            room.CreateRoomObserverSeeingVotes(roomName, false);

            //var body = $"name={roomName}" +
            //    $"&cardSetType=1" +
            //    $"&haveStories=true" +
            //    $"&confirmSkip=true" +
            //    $"&showVotingToObservers=false" +
            //    $"&autoReveal=true" +
            //    $"&changeVote=false" +
            //    $"&countdownTimer=false" +
            //    $"&countdownTimerValue=30";
            //var request = new RestRequest("/api/games/create/", Method.POST);

            //request.AddHeader("Content-Length", body.Length.ToString());
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", cookie);

            //request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            //var response = client.Execute(request);

            //var content = response.Content;
            //var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            //gameId = deserializeObject.gameId;
            //gameCode = deserializeObject.gameCode;
        }

        [When(@"I request information regarding the Game Room")]
        public void WhenIRequestInformationRegardingTheGameRoom()
        {
            var game = new Play(loginContext.gameId, loginContext.gameCode, client, loginContext.cookie);
            room = game.GetRoomInfo();

            //var body = $"gameId={gameId}&";

            //var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            //request.AddHeader("Content-Length", body.Length.ToString());
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", cookie);

            //request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            //var response = client.Execute(request);
            //var content = response.Content;
            //var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            //haveStories = deserializeObject.haveStories;
            //confirmSkip = deserializeObject.confirmSkip;
            //showVotingToObservers = deserializeObject.showVotingToObservers;
        }
        
        [Then(@"I should see that I am unable to add stories to the Game Room")]
        public void ThenIShouldSeeThatIAmUnableToAddStoriesToTheGameRoom()
        {
            room.CheckRoomCannotHaveStories();
        }

        [Then(@"I should see that I do not have to give confirmation for skipping stories")]
        public void ThenIShouldSeeThatIDoNotHaveToGiveConfirmationForSkippingStories()
        {
            room.CheckRoomSkipNotNeedConfirmation();
        }

        [Then(@"I should see that the observer is unable to see the votes during the voting process")]
        public void ThenIShouldSeeThatTheObserverIsUnableToSeeTheVotesDuringTheVotingProcess()
        {
            room.CheckRoomObserverCannotSeeVotes();
        }
    }
}
