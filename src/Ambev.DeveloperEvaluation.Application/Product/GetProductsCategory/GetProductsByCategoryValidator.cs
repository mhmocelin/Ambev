using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

internal class GetProductsByCategoryValidator: AbstractValidator<GetProductsByCategoryCommand>
{
    public GetProductsByCategoryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required");
    }
}
