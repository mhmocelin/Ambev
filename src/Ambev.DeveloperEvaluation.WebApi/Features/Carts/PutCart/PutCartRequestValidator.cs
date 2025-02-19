using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.PutCart;

public class PutCartRequestValidator : AbstractValidator<PutCartRequest>
{
    public PutCartRequestValidator()
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
