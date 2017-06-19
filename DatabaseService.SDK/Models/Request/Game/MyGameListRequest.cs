using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.SDK.Models.Request.Game
{
   public class MyGameListRequest:BaseRequest
    {
        public long userId { get; set; }
    }
}
