
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProductResponse : BaseSaleProduct
{
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }
}
