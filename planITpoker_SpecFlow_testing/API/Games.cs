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
        public int moderatorId;
        public int secondUserId;

        public Games(LoginContext loginContext, RestClient client, string cookie)
        {
            this.client = client;
            this.loginContext = loginContext;
            this.cookie = cookie;
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

        public void GetFirstUserId()
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

            moderatorId = deserializeObject.players[0].id;
        }

        public void GetSecondUserId()
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

            secondUserId = deserializeObject.players[1].id;
        }

        public void ChangeRoleModeratorToObserver()
        {
            var body = $"gameId={GameId}&" + 
                $"&userId={moderatorId}" + 
                $"&role=1";

            var request = new RestRequest("/api/games/updaterole/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public void ChangeRolePlayerToObserver()
        {
            var body = $"gameId={GameId}&" +
                $"&userId={secondUserId}" +
                $"&role=1";

            var request = new RestRequest("/api/games/updaterole/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public void RemovePlayer()
        {
            var body = $"gameId={GameId}" +
                $"&userId={secondUserId}";

            var request = new RestRequest("/api/games/removePlayer/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
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

        public CurrentStory GetCurrentStoryInfo()    //used for the NextStory Test Assert
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getCurrentStory/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentStory>(content);

            return deserializeObject;
        }

        public void ClearVotes()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/resetCurrentStory/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public void ResetGameRoom()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/api/games/reset/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        //this can be used to edit any setting after the room has been created
        //just change method and body parameters
        public void EditCreatedGameRoom(string roomName, bool tf, int duration)
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
        }

        public void DeleteGameRoom()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public List<ListRoom> GetGamesListInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getList/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ListRoom>>(content);

            return deserializeObject;
        }

        public void ResetTimer()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/resetTimer", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public Story GetStoryState()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getStoryState/", Method.POST);

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
