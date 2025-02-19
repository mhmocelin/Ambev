using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.Title).NotEmpty().Length(1, 50);
        RuleFor(p => p.Quantity).NotEmpty();
        RuleFor(p => p.Category).NotEmpty();
        RuleFor(p => p.Rating).NotNull();
    }
}
