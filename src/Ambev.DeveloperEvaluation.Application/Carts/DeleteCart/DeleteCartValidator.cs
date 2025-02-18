using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartValidator :AbstractValidator<DeleteCartCommand>
{
    public DeleteCartValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product Id is required");
    }
}
