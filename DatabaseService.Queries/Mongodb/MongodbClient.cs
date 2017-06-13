using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace DatabaseService.Queries.Mongodb
{

     
   public class MongodbClient
    {
       
       public static IMongoDatabase GetDatabaseClient()
       {
          // string connectionString = @"mongodb://kymuser:secure%40123@ds061385.mongolab.com:61385/kym";
           string connectionString = ConfigurationManager.AppSettings["mogodbconnection"];
        var mongoClient = new MongoClient(connectionString);

           return mongoClient.GetDatabase("mq");
       }
    }
}
