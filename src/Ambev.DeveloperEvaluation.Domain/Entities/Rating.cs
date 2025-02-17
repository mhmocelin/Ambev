using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating : BaseEntity
{
    public decimal Rate { get; set; }
    public int Count { get; set; }
    public Guid ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty(nameof(Product.Id))]
    public virtual Product Product { get; set; }
}