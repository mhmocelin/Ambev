using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.Branch).NotEmpty();
        RuleFor(p => p.SaleProducts).NotEmpty();
    }
}
