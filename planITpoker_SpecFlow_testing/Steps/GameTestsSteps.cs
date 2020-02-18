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
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        private string cookie;
        public int GameId { get; set; }
        public string GameCode { get; set; }

        public GameTestsSteps[] stories { get; set; }
        public GameTestsSteps[] players { get; set; }
        public string title { get; set; }
        public bool moderatorConnected { get; set; }
        public bool gameStarted { get; set; }
        public bool voted { get; set; }

        [Given(@"I log in via Quick Play as ""(.*)""")]
        public void GivenILogInViaQuickPlayAs(string userName)
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
        
        [Given(@"I create a Game Room named ""(.*)""")]
        public void GivenICreateAGameRoomNamed(string roomName)
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

            GameId = deserializeObject.gameId;
            GameCode = deserializeObject.gameCode;
        }
        
        [Given(@"I create a story named ""(.*)""")]
        public void GivenICreateAStoryNamed(string storyName)
        {
            var body = $"gameId={GameId}&" +
                $"name={storyName}";

            var request = new RestRequest("/api/stories/create/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        [Given(@"I start the game")]
        public void GivenIStartTheGame()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        [Given(@"I vote")]
        public void GivenIVote()
        {
            var body = $"gameId={GameId}&" +
                $"vote=2";

            var request = new RestRequest("/api/stories/vote/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        [When(@"I request story information")]
        public void WhenIRequestStoryInformation()
        {
            var body = $"gameId={GameId}&" +
                $"page=1&" +
                $"skip=0&" +
                $"perPage=25&" +
                $"status=0&";

            var request = new RestRequest("/api/stories/get/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameTestsSteps>(content);

            title = deserializeObject.stories[0].title;
        }

        [When(@"I request Game information from getPlayInfo")]
        public void WhenIRequestGameInformationFromGetPlayInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameTestsSteps>(content);

            moderatorConnected = deserializeObject.moderatorConnected;
        }

        [When(@"I request Game information from getPlayersAndState")]
        public void WhenIRequestGameInformationFromGetPlayersAndState()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getPlayersAndState/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameTestsSteps>(content);

            gameStarted = deserializeObject.gameStarted;
        }

        [When(@"I request Vote information")]
        public void WhenIRequestVoteInformation()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/gameStoryVoteEvent", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameTestsSteps>(content);

            voted = deserializeObject.players[0].voted;

        }

        [Then(@"I should see that the story is named ""(.*)""")]
        public void ThenIShouldSeeThatTheStoryIsNamed(string storyName)
        {
            Assert.Equal(storyName, title);
        }

        [Then(@"I should see that the moderator is connected")]
        public void ThenIShouldSeeThatTheModeratorIsConnected()
        {
            Assert.True(moderatorConnected);
        }

        [Then(@"I should see that the game has started")]
        public void ThenIShouldSeeThatTheGameHasStarted()
        {
            Assert.True(gameStarted);
        }

        [Then(@"I should see that I have voted")]
        public void ThenIShouldSeeThatIHaveVoted()
        {
            Assert.True(voted);
        }
    }
}
