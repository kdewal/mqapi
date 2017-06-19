using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatabaseService.Models;
using System.Data.SqlClient;

namespace DatabaseService.Queries.SQL
{
    public static class CommonDao
    {
        private static string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    
 
        public static List<State> State()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_getStates"))
                {
                        dt.Load(dr);
                  
                }

                List<State> ls = new List<State>();
                if (dt != null)
                {
                    ls = dt.AsEnumerable().Select(r => new State
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("name")
                    }).ToList();
                    return ls;
                }
                else
                {
                    throw new InvalidOperationException("Does Not Contain Any State");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Cities> Cities(int stateId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@state_id", SqlDbType.Int);
                param[0].Value = stateId;
                DataTable dt = new DataTable();

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_getCities", param))
                {
                    
                    dt.Load(dr);

                }
                List<Cities> cities = new List<Cities>();
                if (dt != null)
                {
                    cities =  dt.AsEnumerable().Select(r => new Cities
                    {
                        Id = r.Field<int>("Id"),
                        Name = r.Field<string>("name")
                    }).ToList();
                    return cities;
                }
                else
                {
                    throw new InvalidOperationException("Does not contain Any City");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
