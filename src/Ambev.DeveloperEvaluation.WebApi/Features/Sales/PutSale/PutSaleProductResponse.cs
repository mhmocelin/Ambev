using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PutSale;

public class PutSaleProductResponse : BaseSaleProduct
{
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }
}
