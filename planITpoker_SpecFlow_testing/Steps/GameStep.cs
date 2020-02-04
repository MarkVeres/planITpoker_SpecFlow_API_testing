using RestSharp;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace planITpoker_SpecFlow_testing
{
    [Binding]
    public class GameStep
    {
        public int GameId { get; set; }
        public string GameCode { get; set; }
        private RestClient client;
        private string cookie;

        public GameStep(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }

        [When(@"I request Game Room information")]
        public Room GetRoomInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Room>(content);

            return deserializeObject;
        }
    }
}
