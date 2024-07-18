using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UniqueInfo { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Description { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; } = 0!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ImageUrl { get; set; } = null!;
    }
}
