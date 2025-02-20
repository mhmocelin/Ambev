using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

internal class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.Branch).NotEmpty();
        RuleFor(p => p.SaleProducts).NotEmpty();
    }
}

