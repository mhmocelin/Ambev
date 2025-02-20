using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse : BaseSale
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime? SaleCreated { get; set; }
}
