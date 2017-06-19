using System.Web.Http;
using DatabaseService.Queries.SQL;
using DatabaseService.Models;

namespace DatabaseServiceWebService.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public dynamic Register([FromBody] dynamic inputs)
        {
            RegisterSuccess r = new RegisterSuccess();
                r=AccountDaoBase.RegisterUser(inputs);
            return r;
        }
    }
}
