namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

public class GetRatingsResponse
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
