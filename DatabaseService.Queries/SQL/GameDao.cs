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
    public static class GameDao
    {
        private static string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static Game OnGoingGameLIst()
        { 
            try
            {

               DataSet ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "usp_ongoing_games");
              Game g = new Game();
              if (ds.Tables[0] != null)
              {
                  DataTable dt=new DataTable();
                  dt = ds.Tables[0];
                  g.GameList = dt.AsEnumerable().Select(row => new GameList
                  {
                      Id = row.Field<long>("Id"),
                      amount = row.Field<decimal>("amount"),
                      start_at = row.Field<DateTime>("start_at")
                  });
              }
              return g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<GameList> MyGameList(long userid)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@user_id", SqlDbType.BigInt);
                param[0].Value = userid;

                using (var dr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_mygame", param))
                {
                    DataTable dt = new DataTable("MyGameList");
                    while (dr.Read())
                    {
                        dt.Load(dr);
                    }
                    if (null != dt) 
                    {
                        List<GameList> gl = dt.AsEnumerable().Select(row => new GameList
                        {
                            Id = row.Field<long>("Id"),
                            amount = row.Field<decimal>("amount"),
                            start_at = row.Field<DateTime>("start_at")
                        }).ToList();
                        return gl;
                    }
                    else
                    {
                        throw new InvalidOperationException("Internal Server Error");
                    }
                    
                    
                }






                /*Temp Logic*/
                //SqlDataReader dr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_mygame",param);

                //var x = dr.Read();

                ////List<GameList> Result=new List<GameList>();
                //if(!dr.IsClosed)
                //{
                //    while (dr.NextResult())
                //    {
                //        if (dr.HasRows)
                //        {
                //            DataTable dt = new DataTable("MyGameList");
                //            dt.Load(dr);
                //            List<GameList> gl = dt.AsEnumerable().Select(row => new GameList
                //            {
                //                Id = row.Field<long>("Id"),
                //                amount = row.Field<decimal>("amount"),
                //                start_at = row.Field<DateTime>("start_at")
                //            }).ToList();

                //            return gl;

                //        }
                //        
                //    }
                //}
            }
            catch (Exception e)
            {
                BaseClass.logger.Error("Database Query GetRefreshToken: ", e);
                return null;
            }
        }

        public static JoinGame JoinGame(long userId, long gameId)
        {
            try
            {
                SqlParameter[] param=new SqlParameter[2];
                param[0] = new SqlParameter("@user_id", SqlDbType.BigInt);
                param[0].Value = userId;
                param[1] = new SqlParameter("@game_id", SqlDbType.BigInt);
                param[1].Value = gameId;

                SqlDataReader dr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_join_game", param);

                if (dr.HasRows && dr.Read())
                {
                    JoinGame jg = new JoinGame();
                    jg.status =Convert.ToInt32(dr["status"].ToString());
                    jg.message = dr["message"].ToString();
                    return jg;
                }
                else
                {
                    return null;
                    throw new InvalidOperationException("Internal Server Error");
                    
                }

            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Internal Server Error" + e);
            }
        }

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
