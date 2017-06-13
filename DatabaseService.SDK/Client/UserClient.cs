using DatabaseService.Models;
using DatabaseService.SDK.Models.Request.User;
using DatabaseService.SDK.Models.Response.User;
using System.Threading.Tasks;

namespace DatabaseService.SDK.Client
{
    public class UserClient : BaseClient
    {
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var path = "api/Account/Register";
            return await RunClient<RegisterRequest, RegisterSuccess, RegisterResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "User already registered";
                }
                else
                {
                    response.RegisteredUser = result;
                }
            });
        }
    }
}
