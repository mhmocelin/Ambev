namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

public class BaseSale
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public string Branch { get; set; } = string.Empty;    
    public IEnumerable<BaseSaleProduct>? SaleProducts { get; set; }
}
