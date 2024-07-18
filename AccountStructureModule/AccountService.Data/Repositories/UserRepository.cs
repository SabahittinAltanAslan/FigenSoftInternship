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

        public async Task<List<User>?> GetAll()
        {
            var filter = Builders<User>.Filter.Empty;
            //Mongoose kullanımına alışmak için bu şekilde filtre yapıyoruz.

            var result = await userCollection.Find(filter).ToListAsync();

            return result;

        }

        public async Task<User?> GetByUniqueInfo(Guid uniqueInfo)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UniqueInfo, uniqueInfo);

            var result = await userCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task Update(User updatedUser)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UniqueInfo, updatedUser.UniqueInfo);

            await userCollection.FindOneAndReplaceAsync(filter, updatedUser);
        }

        public async Task Remove(Guid uniqueInfo)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UniqueInfo, uniqueInfo);

            await userCollection.DeleteOneAsync(filter);

        }
    }
}
