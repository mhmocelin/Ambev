using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSalesRequestValidator : AbstractValidator<GetSaleRequest>
{
    public GetSalesRequestValidator()
    {
        RuleFor(c=>c.Id).NotNull().NotEmpty();
    }
}
