namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetRatingResponse
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
