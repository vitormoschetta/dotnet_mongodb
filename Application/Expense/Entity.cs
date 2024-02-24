using System.Text.Json.Serialization;
using dotnet_mongodb.Application.CreditCard;
using dotnet_mongodb.Application.Shared;

namespace dotnet_mongodb.Application.Expense;

public class ExpenseEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal Value { get; set; }

    [JsonIgnore]
    public CreditCardEntity CreditCard { get; set; } = null!;
    public Guid CreditCardId { get; set; }
}
