using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.Build.Framework;

namespace algorithm_planner.Models
{
    public class PlannerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        [BsonElement("type")]
        public EPlanner Type { get; set; }
        [Required]
        [BsonElement("name")]        
        public string? Name { get; set; }
        [Required]
        [BsonElement("url")]        
        public string? URL { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("comment")]
        public string? Comment { get; set; }

    }
}
