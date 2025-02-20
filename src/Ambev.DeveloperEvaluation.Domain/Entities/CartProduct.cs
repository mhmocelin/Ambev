using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class CartProduct
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    [ForeignKey(nameof(CartId))]
    public virtual Cart Cart { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
}
