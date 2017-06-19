using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseService.Models;

namespace DatabaseService.SDK.Models.Response.Game
{
    public class MyGameListResponse:BaseResponse
    {
        public List<GameList> MyGameList { get; set; }
    }
}
