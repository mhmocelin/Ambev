using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.PutProduct;

public class PutProductValidator :AbstractValidator<PutProductCommand>
{
    public PutProductValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product Id is required");
    }
}
