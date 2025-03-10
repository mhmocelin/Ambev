﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.Title).NotEmpty().Length(1, 50);
        RuleFor(p => p.Category).NotEmpty();
        RuleFor(p => p.Rating).NotNull();
    }
}
