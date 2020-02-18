using planITpoker_SpecFlow_testing.Context;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace planITpoker_SpecFlow_testing.Methods
{
    public class LoginMethods
    {
        private readonly LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client;

        public LoginMethods(RestClient client, LoginContext loginContext)
        {
            this.client = client;
            this.loginContext = loginContext;
        }
        public RoomMethods QuickPlayLogin(string userName)
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

            loginContext.cookie = cookie;
            return new RoomMethods(loginContext, client);
        }

        public RoomMethods SignUpLogin(string email, string name, string password)  //doesn't work, bad request status
        {
            var body = $"email={email}&" +
                $"&name={name}&" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/register", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            loginContext.cookie = cookie;
            return new RoomMethods(loginContext, client);
        }

        public RoomMethods LoginLogin(string email, string password)
        {
            var body = $"email={email}" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/login", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            loginContext.cookie = cookie;
            return new RoomMethods(loginContext, client);
        }
    }
}
