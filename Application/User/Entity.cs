using System.Text.Json.Serialization;
using dotnet_mongodb.Application.CreditCard;

namespace dotnet_mongodb.Application.User;

public class UserEntity
{
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public List<CreditCardEntity> CreditCards { get; set; } = new List<CreditCardEntity>();
}