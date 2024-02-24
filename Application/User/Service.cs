using dotnet_mongodb.Data;
using MongoDB.Driver;

namespace dotnet_mongodb.Application.User;

public class UserService
{
    private readonly MongoDbContext _db;

    public UserService(MongoDbContext db)
    {
        _db = db;
    }

    public UserEntity Add(string email)
    {
        var user = new UserEntity()
        {
            Email = email
        };
        _db.Users.InsertOne(user);
        return user;
    }

    public UserEntity Get(string email)
    {
        return _db.Users.Find(x => x.Email == email).FirstOrDefault();
    }
}
