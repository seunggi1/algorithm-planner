using MongoDB.Bson;
using MongoDB.Driver;

namespace algorithm_planner.Database
{
    public class Mongo
    {
        public MongoClient Client { get; set; }

        public Mongo(string connectionString)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            Client = new MongoClient(settings);
        }
    }
}
