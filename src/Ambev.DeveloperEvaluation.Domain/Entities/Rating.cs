using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating : BaseEntity
{
    public decimal Rate { get; set; }
    public Guid ProductId { get; set; }
    public virtual int Count { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
}