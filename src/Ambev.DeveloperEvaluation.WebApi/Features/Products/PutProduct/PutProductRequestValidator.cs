using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.PutProduct;

public class PutProductRequestValidator : AbstractValidator<PutProductRequest>
{
    public PutProductRequestValidator()
    {
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.Title).NotEmpty().Length(1, 50);
        RuleFor(p => p.Category).NotEmpty();
        RuleFor(p => p.Rating).NotNull();
    }
}
