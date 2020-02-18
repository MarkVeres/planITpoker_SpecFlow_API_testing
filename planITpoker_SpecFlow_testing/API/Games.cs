using planITpoker_SpecFlow_testing.Context;
using planITpoker_SpecFlow_testing.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace planITpoker_SpecFlow_testing.Methods
{
    public class Games
    {
        public LoginContext loginContext;
        private readonly string cookie;
        private readonly RestClient client;
        public int GameId;

        public Games(LoginContext loginContext, RestClient client)
        {
            this.client = client;
            this.loginContext = loginContext;
            this.cookie = loginContext.cookie;
            this.GameId = loginContext.gameId;
        }

        public void CreateRoom(string roomName)
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void CreateRoomHaveStories(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories={tf}" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void CreateRoomSkipConfirmation(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip={tf}" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void CreateRoomObserverSeeingVotes(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers={tf}" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void CreateRoomAutoVoteReveal(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal={tf}" +
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
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void CreateRoomAllowChangeVote(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote={tf}" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public void UseCountDownTimer(string roomName, bool tf, int duration)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer={tf}" +
                $"&countdownTimerValue={duration}";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Play>(content);
            loginContext.gameId = deserializeObject.GameId;
            loginContext.gameCode = deserializeObject.GameCode;
        }

        public User GetPlayersAndStateInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getPlayersAndState/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public User GetVoteInformation()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/gameStoryVoteEvent", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }
    }
}
