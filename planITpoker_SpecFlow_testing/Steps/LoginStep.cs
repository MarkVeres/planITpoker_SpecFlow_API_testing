using RestSharp;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using BoDi;

namespace planITpoker_SpecFlow_testing.Steps
{
    [Binding]
    public class LoginStep
    {
        private const string baseUrl = "https://www.planitpoker.com";
        private RestClient client;

        public LoginStep()
        {
            client = new RestClient(baseUrl);
        }        

        [Given(@"I have logged in via QuickPlay as ""(.*)""")]
        public CreateRoomStep GivenIHaveLoggedInViaQuickPlayAs(string userName)
        {
            var body = $"name={userName}";
            var request = new RestRequest("/api/authentication/anonymous", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            return new CreateRoomStep(cookie, client);
        }
    }
}
