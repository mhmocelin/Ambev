namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

public class BaseSaleProduct
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }
}
