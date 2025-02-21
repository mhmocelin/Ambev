using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public virtual Rating? Rating { get; set; }

    public void Update(Product product)
    {
        this.Title = product.Title;
        this.Price = product.Price;
        this.Description = product.Description;
        this.Category = product.Category;
        this.Image = product.Image;
        this.Quantity = product.Quantity;
        this.Rating = product.Rating;
    }
}