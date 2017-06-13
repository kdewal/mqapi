using System.Web.Http;
using DatabaseService.Queries.Mongodb;

namespace DatabaseServiceWebService.Controllers
{
    public class CommomController : BaseController
    {
        [HttpPost]
        public dynamic EntityTypeList([FromBody] dynamic inputs)
        {
            return GetEntityTypeQuery.EntityTypeList();
        }
    }
}
