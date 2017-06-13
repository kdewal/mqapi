using DatabaseService.Models;

namespace DatabaseService.SDK.Models.Response.Authentication {
  public class AuthenticateResponse : BaseResponse {
    public DatabaseService.Models.AuthenticatedUser AuthenticatedUser { get; set; }
  }
}
