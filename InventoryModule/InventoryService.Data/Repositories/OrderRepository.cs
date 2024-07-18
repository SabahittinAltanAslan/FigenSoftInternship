using InventoryService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class OrderRepository
    {
        private readonly IMongoCollection<Order> orderCollection;
        public OrderRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OrderDb");
            orderCollection = database.GetCollection<Order>("orders");
        }
        public async Task<List<Order>?> GetAll()
        {
            var filter = Builders<Order>.Filter.Empty;

            var result = await orderCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<Order?> GetByUniqueInfo(Guid uniqueInfo)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.UniqueInfo, uniqueInfo);

            var result = await orderCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Order> Create(Order order)
        {
            await orderCollection.InsertOneAsync(order);
            return order;

        }

        public async Task Update(Order updatedOrder)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, updatedOrder.Id);

            await orderCollection.FindOneAndReplaceAsync(filter, updatedOrder);
        }

        public async Task Remove(Guid uniqueInfo)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.UniqueInfo, uniqueInfo);

            await orderCollection.DeleteOneAsync(filter);

        }
    }
}
