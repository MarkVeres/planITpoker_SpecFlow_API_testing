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
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client = new RestClient(baseUrl);
        private string cookie;
        public int GameId { get; set; }
        public string GameCode { get; set; }
        public string title { get; set; }


        [Given(@"I logged in by Quick Play as ""(.*)""")]
        public void GivenILoggedInByQuickPlayAs(string userName)
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

        [Given(@"I create an account using the following credentials ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenICreateAnAccountUsingTheFollowingCredentials(string email, string name, string password)
        {
            var body = $"email={email}&" +
                $"&name={name}&" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/register", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();
        }

        [Given(@"I logged in using the following credentials ""(.*)"", ""(.*)""")]
        public void GivenILoggedInUsingTheFollowingCredentials(string email, string password)
        {
            var body = $"email={email}" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/login", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();
        }

        [Given(@"I created a Game Room named ""(.*)""")]
        public void GivenICreatedAGameRoomNamed(string roomName)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginTestSteps>(content);

            GameId = deserializeObject.GameId;
            GameCode = deserializeObject.GameCode;
        }
        
        [When(@"I request Game Room information")]
        public void WhenIRequestGameRoomInformation()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginTestSteps>(content);

            title = deserializeObject.title;
        }
        
        [Then(@"The name of the Game Room should be ""(.*)""")]
        public void ThenTheNameOfTheGameRoomShouldBe(string roomTitle)
        {
            Assert.Equal(roomTitle, title);
        }
    }
}
