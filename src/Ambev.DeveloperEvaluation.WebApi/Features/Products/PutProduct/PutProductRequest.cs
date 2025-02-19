namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.PutProduct;

public class PutProductRequest
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public virtual PutRatingRequest? Rating { get; set; }
}
