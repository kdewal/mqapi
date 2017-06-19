using DatabaseService.Models;
using DatabaseService.Queries.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DatabaseServiceWebService.Controllers
{
    public class GameController : BaseController
    {
        [HttpPost]
        public dynamic OnGoingGameList()
        {
            Game g = new Game();
            g = GameDao.OnGoingGameLIst();
            return g;
        }

        [HttpPost]
        public dynamic MyGameList([FromBody] dynamic inputs)
        {
            List<GameList> gl = new List<GameList>();
            gl = GameDao.MyGameList(Convert.ToInt64(inputs.userId));
            return gl;
        }
        [HttpPost]
        public dynamic JoinGame([FromBody] dynamic inputs)
        {
            JoinGame jg = new JoinGame();
            jg = GameDao.JoinGame(Convert.ToInt64(inputs.userId), Convert.ToInt64(inputs.gameId));
            return jg;
        }
        [HttpPost]
        public dynamic State()
        {
            List<State> ls = new List<State>();
            ls = GameDao.State();
            return ls;
        }
        [HttpPost]
        public dynamic Cities([FromBody] dynamic inputs)
        {
            List<Cities> c = new List<Cities>();
            c = GameDao.Cities(Convert.ToInt32(inputs.stateId));
            return c;
        }
    }
}
