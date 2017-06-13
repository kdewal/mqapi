using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DatabaseService.Queries.Mongodb
{
    public static class RegisterUserQuery
    {
        public static void RegisterUser(dynamic inputs)
        {
            try
            {
                string token = inputs.HashedToken;
                string FirstName = inputs.FirstName;
                string LastName = inputs.LastName;
                string PanNumber = inputs.PanNumber;
                string Address1 = inputs.Address1;
                string Address2 = inputs.Address2;
                string City = inputs.PanNumber;
                string State = inputs.State;
                string PostalCode = inputs.PostalCode;
                string PrimaryPhone = inputs.PrimaryPhone;
                string SecondaryPhone = inputs.SecondaryPhone;
                string Email = inputs.Email;
                string HashedPassword = inputs.Password;
         
                var document = new BsonDocument
                            {
                               { "FirstName", FirstName },
                               { "LastName", LastName },
                               { "PanNumber", PanNumber },
                               { "Address1", Address1 },
                               { "Address2", Address2 },
                               { "City", City },
                               { "State", State },
                               { "PostalCode", PostalCode },
                               { "PrimaryPhone", PrimaryPhone },
                               { "SecondaryPhone", SecondaryPhone },
                               { "Email", Email },
                               { "HashedPassword", HashedPassword }
                            };
                var _database = MongodbClient.GetDatabaseClient();
               // var collection = _database.GetCollection<BsonDocument>("client");
                //var filter = Builders<BsonDocument>.Filter.Eq("Id", ClientId);
                //var update = Builders<BsonDocument>.Update.Push("RefreshToken", document);
               // var result = collection.UpdateOne(filter, update);
                var collection = _database.GetCollection<BsonDocument>("user");
                collection.InsertOneAsync(document);
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query Register User: ", ex);
               
            }
        }
    }
}
