using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.TotalSaleAmount).NotEmpty();
        RuleFor(p => p.Branch).NotEmpty();
        RuleFor(p => p.SaleProducts).NotEmpty();
    }
}
