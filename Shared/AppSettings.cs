namespace dotnet_mongodb.Shared;

public class AppSettings
{
    public MongoDbSettings MongoDb { get; set; } = new();
}

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string DatabaseName { get; set; } = "dotnet-mongodb";
    public string CollectionName { get; set; } = "todos";
    public string Username { get; set ; } = "root";
    public string Password { get; set; } = "example";
}
