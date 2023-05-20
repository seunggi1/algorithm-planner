using algorithm_planner.Database;
using algorithm_planner.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace algorithm_planner.Data
{
    public class Planner : IPlanner
    {
        private readonly IMongoDatabase _db;

        public Planner(Mongo db)
        {
            _db = db.Client.GetDatabase("Planner");
        }

        public async Task<List<PlannerModel>> GetAllAsync()
        {
            var planner = _db.GetCollection<PlannerModel>("Planner");

            return await planner.Find(Builders<PlannerModel>.Filter.Empty).ToListAsync();
        }

        public Task<List<PlannerModel>> GatAllTypeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(PlannerModel data)
        {

            var planner = _db.GetCollection<BsonDocument>("Planner");

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

        public async Task<int> UpdateAsync(PlannerUpdateModel data)
        {
            var planner = _db.GetCollection<PlannerModel>("Planner");

            var filter = Builders<PlannerModel>.Filter.Eq(p => p.Id, ObjectId.Parse(data.Id));
            var update = Builders<PlannerModel>.Update.Set(p => p.Type, data.Type);

            var result = await planner.UpdateOneAsync(filter, update);

            return 1;
        }

        public Task<int> DeleteAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}
