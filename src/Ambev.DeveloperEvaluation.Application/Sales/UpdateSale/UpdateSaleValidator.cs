using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

internal class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(p => p.Branch).NotEmpty();
        RuleFor(p => p.SaleProducts).NotEmpty();
        RuleFor(p => p.SaleProducts)
            .Must(p => p.All(x => x.ProductId != Guid.Empty))
            .WithMessage("Product Id cannot be empty");
        RuleFor(p => p.SaleProducts)
            .Must(p => p.All(x => x.Quantity > 0))
            .WithMessage("Product quantity must be greater than 0");
        RuleFor(p => p.SaleProducts)
            .Must(p => p.All(x => x.Quantity <= 20))
            .WithMessage($"Maximum quantity of the product and 200");
    }
}

