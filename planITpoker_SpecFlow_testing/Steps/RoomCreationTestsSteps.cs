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
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        private string cookie;
        public int GameId { get; set; }
        public string GameCode { get; set; }

        public bool haveStories { get; set; }   //does the room allow story creation?
        public bool confirmSkip { get; set; }   //do you have to confirm skipping stories?
        public bool showVotingToObservers { get; set; }   //can the observer see the votes?

        //not yet implemented
        //public bool autoReveal { get; set; }  //automatically reveal the votes when voting finishes?
        //public bool changeVote { get; set; }   //allow players to change vote after they have voted?
        //public bool countdownTimer { get; set; }  //use a countdown timer?

        [Given(@"I log in by Quick Play as ""(.*)""")]
        public void GivenILogInByQuickPlayAs(string userName)
        {
            var body = $"name={userName}";
            var request = new RestRequest("/api/authentication/anonymous", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();
        }
        
        [Given(@"I create a Game Room named ""(.*)"" that cannot have stories")]
        public void GivenICreateAGameRoomNamedThatCannotHaveStories(string roomName)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=false" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            GameId = deserializeObject.GameId;
            GameCode = deserializeObject.GameCode;
        }

        [Given(@"I create a Game Room named ""(.*)"" in which skipping stories does not require confirmation")]
        public void GivenICreateAGameRoomNamedInWhichSkippingStoriesDoesNotRequireConfirmation(string roomName)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=false" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            GameId = deserializeObject.GameId;
            GameCode = deserializeObject.GameCode;
        }

        [Given(@"I create a Game Room named ""(.*)"" in which the observer cannot see the votes during the voting process")]
        public void GivenICreateAGameRoomNamedInWhichTheObserverCannotSeeTheVotesDuringTheVotingProcess(string roomName)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=false" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            GameId = deserializeObject.GameId;
            GameCode = deserializeObject.GameCode;
        }

        [When(@"I request information regarding the Game Room")]
        public void WhenIRequestInformationRegardingTheGameRoom()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RoomCreationTestsSteps>(content);

            haveStories = deserializeObject.haveStories;
            confirmSkip = deserializeObject.confirmSkip;
            showVotingToObservers = deserializeObject.showVotingToObservers;
        }
        
        [Then(@"I should see that I am unable to add stories to the Game Room")]
        public void ThenIShouldSeeThatIAmUnableToAddStoriesToTheGameRoom()
        {
            Assert.False(haveStories);
        }

        [Then(@"I should see that I do not have to give confirmation for skipping stories")]
        public void ThenIShouldSeeThatIDoNotHaveToGiveConfirmationForSkippingStories()
        {
            Assert.False(confirmSkip);
        }

        [Then(@"I should see that the observer is unable to see the votes during the voting process")]
        public void ThenIShouldSeeThatTheObserverIsUnableToSeeTheVotesDuringTheVotingProcess()
        {
            Assert.False(showVotingToObservers);
        }
    }
}
