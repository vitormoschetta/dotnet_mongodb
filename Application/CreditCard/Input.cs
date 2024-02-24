using dotnet_mongodb.Application.Shared;
using dotnet_mongodb.Application.User;
using FluentValidation;

namespace dotnet_mongodb.Application.CreditCard;

public class CreditCardCreateInput : BaseInput
{
    public string Title { get; set; } = string.Empty;

    public override bool IsInvalid
    {
        get
        {
            ValidationResult = new CreditCardCreateInputValidator().Validate(this);
            return !ValidationResult.IsValid;
        }
    }

    public CreditCardEntity ToEntity(UserEntity user) => new()
    {
        Title = Title,
        UserEmail = user.Email,
    };
}

public class CreditCardCreateInputValidator : AbstractValidator<CreditCardCreateInput>
{
    public CreditCardCreateInputValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("O título deve conter pelo menos 3 caracteres");
    }
}