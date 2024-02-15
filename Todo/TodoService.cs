using dotnet_mongodb.Data;
using dotnet_mongodb.Shared;
using MongoDB.Driver;

namespace dotnet_mongodb.Todo;

public class TodoService
{
    private readonly MongoDbContext _context;

    public TodoService(MongoDbContext context)
    {
        _context = context;
    }

    public Output Execute()
    {
        var todos = _context.Todos.Find(todo => true).ToList();
        return Output.Ok(todos);
    }

    public Output Execute(Guid id)
    {
        var todo = _context.Todos.Find(todo => todo.Id == id).FirstOrDefault();
        if (todo == null)
        {
            return Output.Fail(EDomainCode.NotFound, "Todo not found");
        }

        return Output.Ok(todo);
    }

    public Output Execute(TodoCreateInput input)
    {
        if (input.IsInvalid)
            return Output.Fail(EDomainCode.InvalidInput, input.Errors);

        var todo = input.ToEntity();

        _context.Todos.InsertOne(todo);

        return Output.Ok(todo);
    }
}
