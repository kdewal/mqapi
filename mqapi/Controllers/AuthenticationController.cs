using System.Web.Http;

namespace mqapi.Controllers
{
  public class AuthenticationController : BaseController {
    [Authorize]
    [HttpGet]
    public IHttpActionResult TestAuthentication() {
      return Ok(new { Id = CurrentUserId, Username = CurrentUsername, Role = CurrentRole });
    }
  }
}
