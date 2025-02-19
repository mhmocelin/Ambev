namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

public class GetProductsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public virtual GetRatingsResponse Rating { get; set; }
}
