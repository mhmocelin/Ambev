using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSalesResponse : BaseSale
{
    public Guid Id {  get; set; }
    public int SaleNumber { get; set; }
    public bool Cancelled { get; set; }
    public DateTime? SaleCreated { get; set; }
    public DateTime? SaleModified { get; set; }
    public DateTime? SaleCancelled { get; set; }
}
