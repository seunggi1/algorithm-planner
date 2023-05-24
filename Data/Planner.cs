using algorithm_planner.Database;
using algorithm_planner.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace algorithm_planner.Data
{
    public class Planner : IPlanner
    {
        private const string DB_NAME = "Planner";
        private readonly IMongoDatabase _db;

        public Planner(Mongo db)
        {
            _db = db.Client.GetDatabase(DB_NAME);
        }

        public async Task<List<PlannerModel>> GetAllAsync()
        {
            var planner = _db.GetCollection<PlannerModel>(DB_NAME);

            return await planner.Find(Builders<PlannerModel>.Filter.Empty).ToListAsync();
        }

        public async Task<List<PlannerModel>> GatAllTypeAsync(EPlanner type)
        {
            var planner = _db.GetCollection<PlannerModel>(DB_NAME);

            return await planner.Find(Builders<PlannerModel>.Filter.Eq(p => p.Type, type)).ToListAsync();
        }

        public async Task<int> InsertAsync(PlannerModel data)
        {

            var planner = _db.GetCollection<BsonDocument>(DB_NAME);

            var document = new BsonDocument
            {
                { nameof(data.Type).ToLower(), data.Type },
                { nameof(data.Name).ToLower(), data.Name },
                { nameof(data.URL).ToLower() , data.URL },
                { nameof(data.Date).ToLower(), DateTime.Now }
            };

            await planner.InsertOneAsync(document);

            return 1;
        }

        public async Task<int> UpdateAsync(PlannerModel data)
        {
            var planner = _db.GetCollection<PlannerModel>(DB_NAME);

            data.Date = DateTime.Now;

            var filter = Builders<PlannerModel>.Filter.Eq(p => p.Id, data.Id);
            var update = Builders<PlannerModel>.Update.Set(p => p , data);

            var result = await planner.UpdateOneAsync(filter, update);

            return 1;
        }

        public async Task<int> ReplaceAsync(PlannerModel data)
        {
            var planner = _db.GetCollection<PlannerModel>(DB_NAME);

            data.Date = DateTime.Now;
            var filter = Builders<PlannerModel>.Filter.Eq(p => p.Id, data.Id);
            var result = await planner.ReplaceOneAsync(filter, data);

            return 1;
        }

        public async Task<int> DeleteAsync(PlannerModel data)
        {
            var planner = _db.GetCollection<PlannerModel>(DB_NAME);

            var filter = Builders<PlannerModel>.Filter.Eq(p => p.Id, data.Id);
            var result = await planner.DeleteOneAsync(filter);

            return 1;
        }
    }
}
