using dotnet_mongodb.Data;
using dotnet_mongodb.Application.Shared;
using dotnet_mongodb.Application.User;
using MongoDB.Driver;

namespace dotnet_mongodb.Application.CreditCard;

public class CreditCardService
{
    private readonly MongoDbContext _context;

    public CreditCardService(MongoDbContext context)
    {
        _context = context;
    }

    public Output Execute(CreditCardCreateInput input, UserEntity user)
    {
        if (input.IsInvalid)
            return Output.Fail(EDomainCode.InvalidInput, input.Errors);

        var entity = input.ToEntity(user);

        try
        {
            _context.CreditCards.InsertOne(entity);
        }
        catch (MongoException e)
        {
            return Output.Fail(EDomainCode.InternalError, e.Message);
        }

        return Output.Ok(entity);
    }
}
