using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace planITpoker_SpecFlow_testing.Methods
{
    public class GameMethods
    {
        public int gameId { get; set; }
        public string gameCode { get; set; }
        private RestClient client;
        private string cookie;


        public GameMethods(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.gameId = gameId;
            this.gameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }

        public Room GetRoomInfo()
        {
            var body = $"gameId={gameId}&";

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
