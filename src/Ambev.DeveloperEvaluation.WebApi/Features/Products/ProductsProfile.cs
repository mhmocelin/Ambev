﻿using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.PutProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<BaseRating, CreateRatingCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
        CreateMap<CreateRatingResult, BaseRating>();

        CreateMap<Guid, GetProductCommand>()
           .ConstructUsing(id => new GetProductCommand(id));
        CreateMap<GetProductResult, GetProductResponse>();
        CreateMap<GetRatingResult, BaseRating>();

        CreateMap<GetProductsResult, GetProductsResponse>();
        CreateMap<GetRatingsResult, BaseRating>();

        CreateMap<PutProductRequest, UpdateProductCommand>();
        CreateMap<BaseRating, UpdateRatingCommand>();
        CreateMap<UpdateProductResult, PutProductResponse>();
        CreateMap<UpdateRatingResult, BaseRating>();

        CreateMap<Guid, DeleteProductCommand>()
          .ConstructUsing(id => new DeleteProductCommand(id));

        CreateMap<GetProductsByCategoryResult, GetProductsResponse>();
    }
}
