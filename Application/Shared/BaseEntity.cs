using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_mongodb.Application.Shared;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // [BsonId]
    // public ObjectId _Id { get; set; }
}
