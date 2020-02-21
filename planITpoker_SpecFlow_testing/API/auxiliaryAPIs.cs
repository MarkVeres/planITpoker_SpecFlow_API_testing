using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace planITpoker_SpecFlow_testing.API
{
    public class AuxiliaryAPIs
    {
        public int GameId { get; set; }
        public string GameCode { get; set; }
        private RestClient client;
        private string cookie;

        public AuxiliaryAPIs(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }

        public void ExportStories()
        {
            var requestString = "/board/exportstories//" + Convert.ToString(GameId);
            var request = new RestRequest(requestString, Method.GET);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            var response = client.Execute(request);
        }

        public string GetExportInfo()
        {
            string adress = "https://www.planitpoker.com/board/exportstories//" + Convert.ToString(GameId);
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Cookie", cookie);
            string information = webClient.DownloadString(adress);

            return information;
        }

        public void GetInGameRoom()
        {
            string adress = "/rooms/play/" + GameCode;

            var request = new RestRequest(adress, Method.GET);

            request.AddHeader("Cookie", cookie);

            IRestResponse response = client.Execute(request);
        }
    }
}
