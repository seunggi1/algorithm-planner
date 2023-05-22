using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace algorithm_planner.Models
{
    public class PlannerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("type")]
        public EPlanner Type { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("url")]
        public string? URL { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("comment")]
        public string? Comment { get; set; }

    }
}
