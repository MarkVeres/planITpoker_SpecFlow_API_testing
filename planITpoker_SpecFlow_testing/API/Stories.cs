using planITpoker_SpecFlow_testing.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace planITpoker_SpecFlow_testing.API
{
    public class Stories
    {
        public int GameId { get; set; }
        public string gameCode { get; set; }
        private RestClient client;
        private string cookie;

        public Stories(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.gameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }

        public void CreateStory(string storyName)
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

        public void StartGame()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            
            var response = client.Execute(request);
        }

        public void Vote()
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

        public Story GetStoryInformation()
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Story>(content);

            return deserializeObject;
        }
    }
}
