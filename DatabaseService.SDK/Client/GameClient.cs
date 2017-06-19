using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseService.Models;
using DatabaseService.SDK.Models.Request;
using DatabaseService.SDK.Models.Response.Game;
using DatabaseService.SDK.Models.Request.Game;

namespace DatabaseService.SDK.Client
{
    public class GameClient : BaseClient
    {
        public async Task<GameResponse> OnGoingGameList()
        {
            var path = "api/Game/OnGoingGameList";
            var request=new EmptyRequest();
            return await RunClient<EmptyRequest, Game, GameResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.OnGoingGameList = result;
                }
            });
        }
        public async Task<MyGameListResponse> MyGameList(MyGameListRequest request)
        {
            var path = "api/Game/MyGameList";
            return await RunClient<MyGameListRequest, List<GameList>, MyGameListResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.MyGameList = result;
                }
            });
        }
        public async Task<JoinGameResponse> JoinGame(JoinGameRequest request)
        {
            var path = "api/Game/JoinGame";
            return await RunClient<JoinGameRequest, JoinGame, JoinGameResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "Internal Server Error";
                }
                else
                {
                    response.JoinGame = result;
                }
            });
        }
        public async Task<StateResponse> State()
        {
            var path = "api/Game/State";
            var request = new EmptyRequest();
            return await RunClient<EmptyRequest, List<State>, StateResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.StateList = result;
                }
            });
        }
        public async Task<CitiesResponse> cities(CitiesListRequest request)
        {
            var path = "api/Game/Cities";

            return await RunClient<CitiesListRequest, List<Cities>, CitiesResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.citiesList = result;
                }
            });
        }
    }
}
