﻿using System.Threading.Tasks;
using mqapi.Models.Request;
using System.Web.Http;
using DatabaseService.SDK.Client;
using DatabaseService.SDK.Models.Request.User;
using DatabaseService.SDK.Models.Request.Common;


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

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetStateList()
        {
            var client = new CommonClient();
            var response = await client.State();
            if (response.IsSuccess)
            {
                return Ok(response.StateList);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> GetCitiesList([FromBody] CitiesListRequest request)
        {
            var client = new CommonClient();
            var response = await client.cities(request);
            if (response.IsSuccess)
            {
                return Ok(response.citiesList);
            }
            else
            {
                return BadRequest(response.ReasonPhrase);
            }
        }
    }
}
