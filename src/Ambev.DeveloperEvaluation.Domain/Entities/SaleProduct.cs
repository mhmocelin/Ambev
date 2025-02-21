using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid SaleId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }

    [ForeignKey(nameof(SaleId))]
    public virtual Sale Sale { get; set; }

    internal void Calculate(SaleProduct item)
    {
        this.Discounts = calculateDiscount(item.Quantity);
        this.UnitPrice = item.Product.Price;
        this.TotalAmount = item.Quantity * (item.UnitPrice - (item.UnitPrice * (item.Discounts / 100)));
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