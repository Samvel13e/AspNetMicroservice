using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration cofiguration)
        {
            var client = new MongoClient(cofiguration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(cofiguration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(cofiguration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
