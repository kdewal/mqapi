using System.Web.Http;
using DatabaseService.Queries.Mongodb;
using DatabaseService.Models;
using System.Collections.Generic;
using DatabaseService.Queries.SQL;
using System;

namespace DatabaseServiceWebService.Controllers
{
    public class CommonController : BaseController
    {
        [HttpPost]
        public dynamic EntityTypeList([FromBody] dynamic inputs)
        {
            return GetEntityTypeQuery.EntityTypeList();
        }
        [HttpPost]
        public dynamic State()
        {
            List<State> ls = new List<State>();
            ls = CommonDao.State();
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
