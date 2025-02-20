using Ambev.DeveloperEvaluation.Application.Sales.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult : BaseSale
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime? SaleCreated { get; set; }
}
