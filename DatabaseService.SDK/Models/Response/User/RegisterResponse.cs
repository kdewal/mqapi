
namespace DatabaseService.SDK.Models.Response.User
{
    public class RegisterResponse:BaseResponse
    {
        public DatabaseService.Models.RegisterSuccess RegisteredUser { get; set; }
    }
}
