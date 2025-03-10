﻿using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryCommand, IEnumerable<GetProductsByCategoryResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsByCategoryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductsByCategoryResult>> Handle(GetProductsByCategoryCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetProductsByCategoryValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByCategoryAsync(command.Category, cancellationToken);
        if (!product.Any()) 
            throw new KeyNotFoundException($"no product in the category");

        var result = _mapper.Map<IEnumerable<GetProductsByCategoryResult>>(product.AsQueryable());
        return result;
    }
}
