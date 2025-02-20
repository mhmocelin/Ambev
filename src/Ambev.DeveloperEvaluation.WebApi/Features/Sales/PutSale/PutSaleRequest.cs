using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PutSale;

public class PutSaleRequest
{
    public string Branch { get; set; } = string.Empty;
    public IEnumerable<BaseSaleProduct>? SaleProducts { get; set; }
}
