using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;

public class DeleteProductValidator :AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product Id is required");
    }
}
