using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AngularCoreMongoCRUD.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Designation { get; set; } = null!;

        public string Company { get; set; } = null!;

        public string Cityname { get; set; } = null!;
        
        public string Address { get; set; } = null!;
    }
}
