using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DatabaseService.Models;
//using DMI.Models;

namespace DatabaseService.Queries.SQL
{
    public static class AccountDaoBase 
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        public static DatabaseService.Models.AuthenticatedUser AuthenticateUser(string mobilenumber)
        {
            string result = string.Empty;

            try
            {
                SqlParameter[] pvoParams = new SqlParameter[2];
                pvoParams[0] = new SqlParameter("@mobilenumber", SqlDbType.VarChar);
                pvoParams[0].Value = mobilenumber;
                SqlDataReader sdr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_authenticate", pvoParams);
                if (sdr.HasRows && sdr.Read())
                {
                    DatabaseService.Models.AuthenticatedUser au = new Models.AuthenticatedUser();
                    au.Id = sdr["Id"].ToString();
                    au.PrimaryPhone = sdr["PrimaryPhone"].ToString();
                    au.HashedPassword = sdr["Password"].ToString();
                    return au;
                }
                else
                {
                    throw new InvalidOperationException("Mobile number does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static RegisterSuccess RegisterUser(dynamic inputs)
        {
            try
            {


                SqlParameter[] pvoParams = new SqlParameter[12];
                pvoParams[0] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                pvoParams[0].Value = inputs.FirstName;

                pvoParams[1] = new SqlParameter("@LastName", SqlDbType.VarChar);
                pvoParams[1].Value = inputs.LastName;

                pvoParams[2] = new SqlParameter("@PanNumber", SqlDbType.VarChar);
                pvoParams[2].Value = inputs.PanNumber;

                pvoParams[3] = new SqlParameter("@Address1", SqlDbType.VarChar);
                pvoParams[3].Value = inputs.Address1;

                pvoParams[4] = new SqlParameter("@Address2", SqlDbType.VarChar);
                pvoParams[4].Value = inputs.Address2;

                pvoParams[5] = new SqlParameter("@City", SqlDbType.VarChar);
                pvoParams[5].Value = inputs.City;

                pvoParams[6] = new SqlParameter("@State", SqlDbType.VarChar);
                pvoParams[6].Value = inputs.State;

                pvoParams[7] = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                pvoParams[7].Value = inputs.PostalCode;

                pvoParams[8] = new SqlParameter("@PrimaryPhone", SqlDbType.VarChar);
                pvoParams[8].Value = inputs.PrimaryPhone;

                pvoParams[9] = new SqlParameter("@SecondaryPhone", SqlDbType.VarChar);
                pvoParams[9].Value = inputs.SecondaryPhone;

                pvoParams[10] = new SqlParameter("@Email", SqlDbType.VarChar);
                pvoParams[10].Value = inputs.Email;

                pvoParams[11] = new SqlParameter("@Password", SqlDbType.VarChar);
                pvoParams[11].Value = inputs.Password;
                SqlDataReader dr= SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_registerUser", pvoParams);

                if (dr.HasRows && dr.Read())
                {
                    RegisterSuccess rs = new RegisterSuccess();
                    rs.FirstName = dr["FirstName"].ToString();
                    rs.LastName=dr["LastName"].ToString();
                    rs.PanNumber=dr["PanNumber"].ToString();
                    rs.Address1=dr["Address1"].ToString();
                    rs.Address2=dr["Address2"].ToString();
                    rs.City=dr["City"].ToString();
                    rs.State=dr["State"].ToString();
                    rs.PostalCode=Convert.ToInt32(dr["PostalCode"].ToString());
                    rs.PrimaryPhone=dr["PrimaryPhone"].ToString();
                    rs.SecondaryPhone=dr["SecondaryPhone"].ToString();
                    rs.Email=dr["Email"].ToString();
                    rs.AgreeToTerms=Convert.ToBoolean(dr["AgreeToTerms"].ToString());
                    rs.DateAdded = Convert.ToDateTime(dr["DateAdded"].ToString());
                    return rs;
                }
                else
                {
                    throw new InvalidOperationException("Internal Server error");
                }

                // var collection = _database.GetCollection<BsonDocument>("client");
                //var filter = Builders<BsonDocument>.Filter.Eq("Id", ClientId);
                //var update = Builders<BsonDocument>.Update.Push("RefreshToken", document);
                // var result = collection.UpdateOne(filter, update);
                //var collection = _database.GetCollection<BsonDocument>("user");
                //collection.InsertOneAsync(document);
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query Register User: ", ex);
                return null;
            }
        }
        public static DatabaseService.Models.Client GetClient(int ClientId)
        {
            try
            {
                SqlParameter[] pvoParams = new SqlParameter[1];
                pvoParams[0] = new SqlParameter("@ClientId", SqlDbType.Int);
                pvoParams[0].Value = ClientId;
                SqlDataReader sdr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_GetClient", pvoParams);
                if (sdr.HasRows && sdr.Read())
                {
                    DatabaseService.Models.Client c = new DatabaseService.Models.Client();
                    c.Id = Convert.ToInt32(sdr["client_id"]);
                    c.Secret = sdr["client_secret"].ToString();
                    c.Name = sdr["name"].ToString();
                    c.Active = Convert.ToBoolean(sdr["active"]);
                    c.RefreshTokenLifeTime = Convert.ToInt32(sdr["refresh_token_life_time"]);
                    c.AllowedOrigin = sdr["allowed_origin"].ToString();

                    return c;
                }
                else
                {
                    throw new InvalidOperationException("Mobile number does not exist.");
                }
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query GetClient: ", ex);
                return null;
            }
        }


        public static DatabaseService.Models.RefreshToken GetRefreshToken(string HashedToken)
        {
            try
            {
                SqlParameter[] pvoParams = new SqlParameter[1];
                pvoParams[0] = new SqlParameter("@HashedToken", SqlDbType.VarChar);
                pvoParams[0].Value = HashedToken;
                SqlDataReader sdr = SqlHelper.ExecuteReader(connectionstring, CommandType.StoredProcedure, "usp_GetRefreshToken", pvoParams);
                if (sdr.HasRows && sdr.Read())
                {
                    DatabaseService.Models.RefreshToken rt = new DatabaseService.Models.RefreshToken();
                    rt.Token = sdr["token"].ToString();
                    rt.Username = sdr["username"].ToString();
                    rt.ClientId = Convert.ToInt32(sdr["client_id"]);
                    rt.IssuedUtc = Convert.ToDateTime(sdr["issued_on"]);
                    rt.ExpiresUtc = Convert.ToDateTime(sdr["expires_on"]);
                    rt.ProtectedTicket = sdr["protected_ticket"].ToString();

                    return rt;
                }
                else
                {
                    throw new InvalidOperationException("Mobile number does not exist.");
                }
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query GetRefreshToken: ", ex);
                return null;
            }

        }
        public static void SaveRefreshToken(dynamic inputs)
        {
            try
            {
                SqlParameter[] pvoParams = new SqlParameter[6];
                pvoParams[0] = new SqlParameter("@HashedToken", SqlDbType.VarChar);
                pvoParams[0].Value = inputs.HashedToken;

                pvoParams[1] = new SqlParameter("@Username", SqlDbType.VarChar);
                pvoParams[1].Value = inputs.Username;

                pvoParams[2] = new SqlParameter("@ClientId", SqlDbType.Int);
                pvoParams[2].Value = inputs.ClientId;

                pvoParams[3] = new SqlParameter("@ExpiresUtc", SqlDbType.DateTime);
                pvoParams[3].Value = inputs.ExpiresUtc;

                pvoParams[4] = new SqlParameter("@IssuedUtc", SqlDbType.DateTime);
                pvoParams[4].Value = inputs.IssuedUtc;

                pvoParams[5] = new SqlParameter("@ProtectedTicket", SqlDbType.VarChar);
                pvoParams[5].Value = inputs.ProtectedTicket;

            
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_insertRefreshToken", pvoParams);


            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query SaveRefreshToken: ", ex);

            }
        }

        public static void DeleteRefreshToken(string HashedToken)
        {

            SqlParameter[] pvoParams = new SqlParameter[1];
            pvoParams[0] = new SqlParameter("@HashedToken", SqlDbType.VarChar);
            pvoParams[0].Value = HashedToken;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_deleteRefreshToken", pvoParams);

        }
    }
}