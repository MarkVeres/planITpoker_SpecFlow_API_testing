using RestSharp;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace planITpoker_SpecFlow_testing
{
    [Binding]
    public class CreateRoomStep
    {
        private readonly string cookie;
        private readonly RestClient client;

        public CreateRoomStep(string cookie, RestClient client)
        {
            this.cookie = cookie;
            this.client = client;
        }

        [Given(@"I create a Game Room named ""(.*)""")]
        public GameStep CreateRoom(string p0)
        {
            var body = $"name={p0}" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameStep>(content);

            return new GameStep(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }
    }
}
