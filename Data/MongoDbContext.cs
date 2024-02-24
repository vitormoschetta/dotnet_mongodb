using dotnet_mongodb.Application.CreditCard;
using dotnet_mongodb.Application.Expense;
using dotnet_mongodb.Application.Shared;
using dotnet_mongodb.Todo;
using dotnet_mongodb.Application.User;
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
        public IMongoCollection<UserEntity> Users => _database.GetCollection<UserEntity>(_collectionName);
        public IMongoCollection<CreditCardEntity> CreditCards => _database.GetCollection<CreditCardEntity>(_collectionName);
        public IMongoCollection<ExpenseEntity> Expenses => _database.GetCollection<ExpenseEntity>(_collectionName);
    }
}