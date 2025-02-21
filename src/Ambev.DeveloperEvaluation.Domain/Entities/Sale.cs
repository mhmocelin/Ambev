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

    public async Task CalculateAsync()
    {
        foreach (var item in SaleProducts)
        {
            item.Discounts = calculateDiscount(item.Quantity);
            item.UnitPrice = item.Product.Price;
            item.TotalAmount = item.Quantity * (item.UnitPrice - (item.UnitPrice * (item.Discounts / 100)));
        }

        this.TotalSaleAmount = SaleProducts.Sum(x => x.TotalAmount);
    }

    public void Update(Sale sale)
    {
        this.SaleModified = DateTime.UtcNow;
        this.Branch = sale.Branch;
        this.SaleProducts = sale.SaleProducts;
    }

    private decimal calculateDiscount(int quantity)
    {
        switch (quantity)
        {
            case >= 10:
                return 20;
            case >= 4:
                return 10;
            default:
                return 0;
        }
    }
}