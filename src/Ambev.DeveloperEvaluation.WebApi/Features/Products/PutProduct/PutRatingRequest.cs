namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.PutProduct;

public class PutRatingRequest
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
