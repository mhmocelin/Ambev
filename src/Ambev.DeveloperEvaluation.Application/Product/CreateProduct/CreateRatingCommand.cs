namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateRatingCommand
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
