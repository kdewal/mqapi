﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.SDK.Models.Request.Common
{
    public class CitiesListRequest : BaseRequest
    {
        public string stateId { get; set; }
    }
}
