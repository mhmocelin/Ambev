namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

public class BaseProduct
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public virtual BaseRating Rating { get; set; }
}
