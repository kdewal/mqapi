using System;
using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using mqapi.Models.Request;
//using AdminSite.Utility.Mvc;
//using Newtonsoft.Json;
using System.Web.Http;
using DatabaseService.SDK.Client;
using DatabaseService.SDK.Models.Request.User;
using mqlib;


namespace mqapi.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody] RegisterRequest parameters)
        {
            if (parameters.Password != parameters.PasswordConfirmation)
            {
                throw new InvalidOperationException("Passwords do not match");
            }
            var client = new UserClient();
           // var request = new RegisterRequest() { };
            var hashedPassword = PasswordHelper.HashPassword(parameters.Password);
            parameters.Password = hashedPassword;
            var response = await client.Register(parameters);

            if (response.IsSuccess)
            {
                return Ok(response.RegisteredUser);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }

    }
}
