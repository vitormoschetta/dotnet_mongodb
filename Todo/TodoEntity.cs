using dotnet_mongodb.Shared;

namespace dotnet_mongodb.Todo;

public class TodoEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; }
}
