using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Data.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UniqueInfo { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string UserName { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Surname { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string PhoneNumber { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Address { get; set; } = null!;

    }
}
