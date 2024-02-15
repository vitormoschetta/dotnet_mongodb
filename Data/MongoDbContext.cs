using dotnet_mongodb.Shared;
using dotnet_mongodb.Todo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dotnet_mongodb.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public MongoDbContext(IOptions<AppSettings> appSettings)
        {
            var client = new MongoClient(appSettings.Value.MongoDb.ConnectionString);
            _database = client.GetDatabase(appSettings.Value.MongoDb.DatabaseName);
            _collectionName = appSettings.Value.MongoDb.CollectionName;
        }

        public IMongoCollection<TodoEntity> Todos => _database.GetCollection<TodoEntity>(_collectionName);
    }
}