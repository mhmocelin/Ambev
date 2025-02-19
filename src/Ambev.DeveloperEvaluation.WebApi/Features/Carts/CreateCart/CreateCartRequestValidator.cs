using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .WithMessage("User ID is required");

        RuleFor(x => x.Products)
            .NotEmpty()
            .NotNull()
            .WithMessage("Products is required");
    }
}
