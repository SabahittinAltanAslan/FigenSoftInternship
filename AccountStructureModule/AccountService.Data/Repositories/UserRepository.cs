using AccountService.Data.Entities;
using Amazon.Runtime.Internal.Util;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Data.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> userCollection;
        public UserRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("AccountStructureDb");

            this.userCollection = database.GetCollection<User>("users");

        }

        public async Task<User> Create(User user)
        {
            await userCollection.InsertOneAsync(user);

            return user;
        }
    }
}
