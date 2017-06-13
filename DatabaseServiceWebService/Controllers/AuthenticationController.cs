using System.Web.Http;
using DatabaseService.Queries.SQL;

namespace DatabaseServiceWebService.Controllers
{
  public class AuthenticationController : BaseController {
    [HttpPost]
    public dynamic Authenticate([FromBody] dynamic inputs) {
        
        string username = inputs.Username;
        logger.Debug("Checking authentication for user : " + username);
        return AccountDaoBase.AuthenticateUser(username);
    }

    [HttpPost]
    public dynamic GetClient([FromBody] dynamic inputs)
    {

        int i = inputs.ClientId;
        logger.Debug("Retrieving client with id: " + i.ToString());
        return AccountDaoBase.GetClient(i);
    }

    [HttpPost]
    public dynamic GetRefreshToken([FromBody] dynamic inputs)
    {
        //logger.DebugFormat("Checking authentication for refresh token: {0}", inputs.RefreshToken);
        return AccountDaoBase.GetRefreshToken(inputs.HashedToken);

    }

    [HttpPost]
    public dynamic SaveRefreshToken([FromBody] dynamic inputs)
    {
        AccountDaoBase.SaveRefreshToken(inputs);
        return null;
    }

    [HttpPost]
    public dynamic DeleteRefreshToken([FromBody] dynamic inputs)
    {
        AccountDaoBase.DeleteRefreshToken(inputs.HashedToken);
        return null;
    }
  }
}
