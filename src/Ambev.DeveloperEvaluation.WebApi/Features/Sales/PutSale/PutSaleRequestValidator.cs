using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PutSale;

public class PutSaleRequestValidator : AbstractValidator<PutSaleRequest>
{
    public PutSaleRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.Branch).NotEmpty();
        RuleFor(p => p.SaleProducts).NotEmpty();
    }
}
