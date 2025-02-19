﻿using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductsHandler : IRequestHandler<GetProductsCommand, GetProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductsResult> Handle(GetProductsCommand command, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        if (products == null) 
            throw new KeyNotFoundException($"no registered product");

        var result = _mapper.Map<GetProductsResult>(products);
        return result;
    }
}
