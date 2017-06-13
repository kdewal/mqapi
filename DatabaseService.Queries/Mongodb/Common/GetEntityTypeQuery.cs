using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseService.Queries.Mongodb
{
    public static class GetEntityTypeQuery
    {
        public static IEnumerable<DatabaseService.Models.EntityType> EntityTypeList()
        {
            try
            {
                Mapper.CreateMap<DatabaseService.Models.EntityType, EntityType>().ForMember(src => src._id, option => option.Ignore()).ReverseMap();
                var _database = MongodbClient.GetDatabaseClient();
                var collection = _database.GetCollection<BsonDocument>("entity_type").ToJson();
               // var doc = collection.Find().ToList();
                var result = JsonConvert.DeserializeObject<IEnumerable<DatabaseService.Models.EntityType>>(collection); ;
                return result;
            }
            catch (Exception ex)
            {
                BaseClass.logger.Error("Database Query AuthenticateUser: ", ex);
                return null;
            }
        }
    }

    
}
