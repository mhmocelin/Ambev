﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public virtual GetRatingResponse Rating { get; set; }
}
