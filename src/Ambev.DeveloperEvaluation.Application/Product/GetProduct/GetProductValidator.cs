using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

internal class GetProductValidator : AbstractValidator<GetProductCommand>
{
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
