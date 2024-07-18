using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UniqueInfo { get; set; }


        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime OrderDate { get; set; }


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string UserId { get; set; } = null!;

    }
}
