using dotnet_mongodb.Data;
using dotnet_mongodb.Application.Shared;
using MongoDB.Driver;

namespace dotnet_mongodb.Application.Expense;

public class ExpenseService
{
    private readonly MongoDbContext _db;

    public ExpenseService(MongoDbContext db)
    {
        _db = db;
    }

    public Output Execute(ExpenseCreateInput input, Guid creditCardId)
    {
        if (input.IsInvalid)
            return Output.Fail(EDomainCode.InvalidInput, input.Errors);
        
        var creditCard = _db.CreditCards.Find(x => x.Id == creditCardId).FirstOrDefault();

        if (creditCard == null)
            return Output.Fail(EDomainCode.NotFound, "Cartão de crédito não encontrado");

        var entity = input.ToEntity(creditCard);

        var expense = _db.Expenses.Find(x => x.CreditCardId == creditCardId && x.Title == entity.Title).FirstOrDefault();

        if (expense != null)
            return Output.Fail(EDomainCode.AlreadyExists, "Já existe uma despesa com esse nome");

        _db.Expenses.InsertOne(entity);

        return Output.Ok(entity);
    }
}
