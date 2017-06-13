using System.Threading.Tasks;
using mqapi.Models.Request;
using System.Web.Http;
using DatabaseService.SDK.Client;
using DatabaseService.SDK.Models.Request.User;


namespace mqapi.Controllers
{
    public class CommonController : BaseController {

       // [HttpPost]
        //public async Task<IHttpActionResult> GetEntityTypes()
        //{
        //    var client = new CommonClient();
        //    var response = await client.GetEntityTypeList();

        //    if (response.IsSuccess)
        //    {
        //        return Ok(response.EntityTypeList);
        //    }
        //    else
        //    {
        //        return BadRequest(response.ReasonPhrase);
        //    }
        //}
    }
}
