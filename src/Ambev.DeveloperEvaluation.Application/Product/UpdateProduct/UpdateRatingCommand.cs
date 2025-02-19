namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public class UpdateRatingCommand
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
