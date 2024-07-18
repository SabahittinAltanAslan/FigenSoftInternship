using InventoryService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        public ProductRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventoryDb");
            productCollection = database.GetCollection<Product>("products");
        }
        public async Task<List<Product>?> GetAll()
        {
            var filter = Builders<Product>.Filter.Empty;

            var result = await productCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<Product?> GetByUniqueInfo(Guid uniqueInfo)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.UniqueInfo,uniqueInfo);

            var result = await productCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Product> Create(Product product)
        {
            await productCollection.InsertOneAsync(product);
            return product;

        }

        public async Task Update(Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(x=>x.Id, updatedProduct.Id);

            await productCollection.FindOneAndReplaceAsync(filter,updatedProduct);
        }

        public async Task Remove(Guid uniqueInfo)
        {
            var filter = Builders<Product>.Filter.Eq(x=>x.UniqueInfo,uniqueInfo);

            await productCollection.DeleteOneAsync(filter);

        }
    }
}
