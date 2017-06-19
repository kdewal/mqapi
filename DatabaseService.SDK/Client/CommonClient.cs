using DatabaseService.Models;
using DatabaseService.Models.Enums;
using DatabaseService.SDK.Models.Request.Common;
using DatabaseService.SDK.Models.Response.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using mqlib;
using DatabaseService.SDK.Models.Request;

namespace DatabaseService.SDK.Client
{
    public class CommonClient:BaseClient
    {
        public async Task<FullEntityResponse> GetFullEntityType(FullEntityRequest request)
        {
            var path = "api/Common/EntityTypeList";
            return await RunClient<FullEntityRequest, IEnumerable<EntityType>, FullEntityResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                }
                else
                {
                    response.EntityTypeList = result;
                }
            });
        }
        public async Task<StateResponse> State()
        {
            var path = "api/Common/State";
            var request = new EmptyRequest();
            return await RunClient<EmptyRequest, List<State>, StateResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.StateList = result;
                }
            });
        }
       
        public async Task<CitiesResponse> cities(CitiesListRequest request)
        {
            var path = "api/Common/Cities";

            return await RunClient<CitiesListRequest, List<Cities>, CitiesResponse>(request, path, (result, response) =>
            {
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.ReasonPhrase = "";
                }
                else
                {
                    response.citiesList = result;
                }
            });
        }
        //public async Task<FullEntityResponse> GetEntityTypeList()
        //{
        //    kymCache kC=new kymCache();
        //    var FullEntityList = kC.GetFromCache(CacheKey.EntityTypeList.ToString());
        //    if (FullEntityList == null)
        //    {
        //        var response = await GetFullEntityType(new FullEntityRequest { });
        //        if (response.IsSuccess)
        //        {
        //            FullEntityList = response.EntityTypeList;
        //            kC.AddToCache("EntityTypeList", response.EntityTypeList);
        //        }
        //    }
        //    FullEntityResponse response1 = new FullEntityResponse();
        //    response1.EntityTypeList = from b in FullEntityList
        //               where b.Active==true
        //               select b.Id.b.Name;
        //    return response1;

        //}
        //public async Task<RegisterResponse> GetEntitySubType(RegisterRequest request)
        //{
        //    var path = "api/Account/Register";
        //    return await RunClient<RegisterRequest, User, RegisterResponse>(request, path, (result, response) =>
        //    {
        //        if (result == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ReasonPhrase = "Email already exists";
        //        }
        //        else
        //        {
        //            response.RegisteredUser = result;
        //        }
        //    });
        //}
        //public async Task<RegisterResponse> GetLocations(RegisterRequest request)
        //{
        //    var path = "api/Account/Register";
        //    return await RunClient<RegisterRequest, User, RegisterResponse>(request, path, (result, response) =>
        //    {
        //        if (result == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ReasonPhrase = "Email already exists";
        //        }
        //        else
        //        {
        //            response.RegisteredUser = result;
        //        }
        //    });
        //}
        //public async Task<RegisterResponse> GetCountries(RegisterRequest request)
        //{
        //    var path = "api/Account/Register";
        //    return await RunClient<RegisterRequest, User, RegisterResponse>(request, path, (result, response) =>
        //    {
        //        if (result == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ReasonPhrase = "Email already exists";
        //        }
        //        else
        //        {
        //            response.RegisteredUser = result;
        //        }
        //    });
        //}
        //public async Task<RegisterResponse> GetStates(RegisterRequest request)
        //{
        //    var path = "api/Account/Register";
        //    return await RunClient<RegisterRequest, User, RegisterResponse>(request, path, (result, response) =>
        //    {
        //        if (result == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ReasonPhrase = "Email already exists";
        //        }
        //        else
        //        {
        //            response.RegisteredUser = result;
        //        }
        //    });
        //}
        //public async Task<RegisterResponse> GetCities(RegisterRequest request)
        //{
        //    var path = "api/Account/Register";
        //    return await RunClient<RegisterRequest, User, RegisterResponse>(request, path, (result, response) =>
        //    {
        //        if (result == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ReasonPhrase = "Email already exists";
        //        }
        //        else
        //        {
        //            response.RegisteredUser = result;
        //        }
        //    });
        //}
    }
}
