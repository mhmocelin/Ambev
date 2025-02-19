namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public class UpdateProductResult
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public virtual UpdateRatingResult? Rating { get; set; }
}
