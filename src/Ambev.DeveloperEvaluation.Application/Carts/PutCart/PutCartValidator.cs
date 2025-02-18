using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartValidator : AbstractValidator<PutCartCommand>
{
    public PutCartValidator()
    {
        RuleFor(x=>x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("date is required");

        RuleFor(x => x.Products)
            .NotEmpty()
            .NotNull()
            .WithMessage("Products are required");
    }
}
