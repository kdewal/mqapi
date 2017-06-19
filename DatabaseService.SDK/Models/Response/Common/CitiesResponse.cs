using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseService.Models;

namespace DatabaseService.SDK.Models.Response.Common
{
    public class CitiesResponse : BaseResponse
    {
        public List<Cities> citiesList { get; set; }
    }
}
