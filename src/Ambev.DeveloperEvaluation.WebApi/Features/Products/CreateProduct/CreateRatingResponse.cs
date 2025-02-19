namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateRatingResponse
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
