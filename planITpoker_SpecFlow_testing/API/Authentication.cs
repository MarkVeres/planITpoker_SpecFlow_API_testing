using planITpoker_SpecFlow_testing.Context;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace planITpoker_SpecFlow_testing.Methods
{
    public class Authentication
    {
        private readonly LoginContext loginContext;
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client;

        public Authentication(RestClient client, LoginContext loginContext)
        {
            this.client = client;
            this.loginContext = loginContext;
        }
        public Games QuickPlayLogin(string userName)
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
            return new Games(loginContext, client);
        }

        public Games SignUpLogin(string email, string name, string password)  //doesn't work, bad request status
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
            return new Games(loginContext, client);
        }

        public Games LoginLogin(string email, string password)
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
            return new Games(loginContext, client);
        }
    }
}
