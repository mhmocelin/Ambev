namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

public class BaseRating
{
    public decimal Rate { get; set; }
    public virtual int Count { get; set; }
}
