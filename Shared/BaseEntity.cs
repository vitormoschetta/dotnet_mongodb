namespace dotnet_mongodb.Shared;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
