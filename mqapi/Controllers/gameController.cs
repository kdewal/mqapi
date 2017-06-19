using DatabaseService.SDK.Client;
using mqapi.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Threading.Tasks;
using smapi.Models.Request;
using DatabaseService.SDK.Models.Request.Game;

namespace smapi.Controllers
{
    [Authorize]
    public class gameController : BaseController
    {
        //Get the on going game List
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetOnGoingGameList()
        {
            var client =  new GameClient();
            var response =await client.OnGoingGameList();
            if (response.IsSuccess)
            {
                return Ok(response.OnGoingGameList);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> GetMyGameList([FromBody]MyGameListRequest model)
        {
            var client = new GameClient();

            var response = await client.MyGameList(model);
            if (response.IsSuccess)
            {
                return Ok(response.MyGameList);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> JoinGame([FromBody] JoinGameRequest request)
        {
            var client = new GameClient();
            var response = await client.JoinGame(request);
            if (response.IsSuccess)
            {
                return Ok(response.JoinGame);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }
    }
}
