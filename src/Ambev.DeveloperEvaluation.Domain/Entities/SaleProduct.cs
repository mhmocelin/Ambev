using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleProduct
{
    public Guid ProductId { get; set; }
    public Guid SaleId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discounts { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty(nameof(Product.Id))]
    public virtual Product Product { get; set; }

    [ForeignKey(nameof(Sale))]
    [InverseProperty(nameof(Sale.Id))]
    public virtual Sale Sale { get; set; }
}