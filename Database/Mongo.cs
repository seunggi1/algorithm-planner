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
            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            Client = new MongoClient(settings);
        }
    }
}
