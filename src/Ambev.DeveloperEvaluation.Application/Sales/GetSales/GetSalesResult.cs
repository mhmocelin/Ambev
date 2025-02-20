using Ambev.DeveloperEvaluation.Application.Sales.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesResult : BaseSale
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public bool Cancelled { get; set; }
    public DateTime? SaleCreated { get; set; }
    public DateTime? SaleModified { get; set; }
    public DateTime? SaleCancelled { get; set; }
    public List<GetSalesProductResult> SaleProducts { get; set; }
}
