﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductRequest
{
    public Guid Id { get; set; }

    public GetProductRequest(Guid id) => this.Id = id;
}
