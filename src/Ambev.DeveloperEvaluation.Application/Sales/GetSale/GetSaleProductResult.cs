using Ambev.DeveloperEvaluation.Application.Sales.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleProductResult : BaseSaleProduct
{
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }
}
