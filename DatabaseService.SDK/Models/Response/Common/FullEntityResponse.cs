using DatabaseService.Models;
using System.Collections.Generic;

namespace DatabaseService.SDK.Models.Response.Common
{
    public class FullEntityResponse:BaseResponse
    {
        public IEnumerable<EntityType> EntityTypeList { get; set; }
    }
}
