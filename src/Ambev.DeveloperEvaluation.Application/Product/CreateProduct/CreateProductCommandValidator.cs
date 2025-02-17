using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.Title).NotEmpty().Length(1, 50);
        RuleFor(p => p.Quantity).NotEmpty();
        RuleFor(p => p.Category).NotEmpty();
        RuleFor(p => p.Rating).NotNull();
    }
}
