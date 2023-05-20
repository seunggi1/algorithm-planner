using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace algorithm_planner.Models
{
    public class PlannerModel
    {
        public ObjectId Id { get; set; }
        [BsonElement("type")]
        public int Type { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("url")]
        public string? URL { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
    }

    public class PlannerUpdateModel
    {
        public string Id { get; set; }
        public int Type { get; set; }
    }
}
