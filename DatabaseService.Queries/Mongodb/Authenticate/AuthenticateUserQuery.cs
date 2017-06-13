using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;


namespace DatabaseService.Queries.Mongodb
{
    public static class AuthenticateUserQuery
    {
        public static DatabaseService.Models.User AuthenticateUser(string mobilenumber)
        {
            try
            {
                Mapper.CreateMap<DatabaseService.Models.User, User>().ForMember(src => src._id, option => option.Ignore()).ReverseMap();
                var _database = MongodbClient.GetDatabaseClient();
                var collection = _database.GetCollection<BsonDocument>("user");
                var filter = Builders<BsonDocument>.Filter.Eq("PrimaryPhone", mobilenumber);
                var doc = collection.Find(filter).ToList();
                var result = BsonSerializer.Deserialize<User>(doc[0]);
                return Mapper.Map<DatabaseService.Models.User>(result);
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query AuthenticateUser: ", ex);
                return null;
            }
        }
    }

    
}
