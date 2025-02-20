using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int SaleNumber { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool Cancelled { get; set; }
    public DateTime? SaleCreated { get; set; }
    public DateTime? SaleModified { get; set; }
    public DateTime? SaleCancelled { get; set; }
    public virtual ICollection<SaleProduct>? SaleProducts { get; set; }
}