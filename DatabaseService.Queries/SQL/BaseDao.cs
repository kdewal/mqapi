using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseService.Queries.SQL
{
    public class BaseDao
    {
       public static string connectionstring=ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
    }
}
