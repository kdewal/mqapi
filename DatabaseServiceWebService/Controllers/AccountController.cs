using System.Web.Http;
using DatabaseService.Queries.SQL;

namespace DatabaseServiceWebService.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public dynamic Register([FromBody] dynamic inputs)
        {
            return AccountDaoBase.RegisterUser(inputs);
        }
    }
}
