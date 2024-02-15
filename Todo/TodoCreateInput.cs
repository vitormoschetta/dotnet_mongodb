using dotnet_mongodb.Shared;
using FluentValidation;

namespace dotnet_mongodb.Todo;

public class TodoCreateInput : BaseInput
{
    public string Title { get; set; } = string.Empty;

    public override bool IsInvalid
    {
        get
        {
            ValidationResult = new TodoCreateInputValidator().Validate(this);
            return !ValidationResult.IsValid;
        }
    }

    public TodoEntity ToEntity() => new()
    {
        Title = Title,
        Done = false
    };
}

public class TodoCreateInputValidator : AbstractValidator<TodoCreateInput>
{
    public TodoCreateInputValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("O título deve conter pelo menos 3 caracteres");
    }
}