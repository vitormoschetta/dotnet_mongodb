namespace dotnet_mongodb.Application.Shared;

public class AppSettings
{
    public MongoDbSettings MongoDb { get; set; } = new();
}

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}
