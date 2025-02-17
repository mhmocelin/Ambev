using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Product.PutProduct;

public  class PutProductHandler : IRequestHandler<PutProductCommand, PutProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public PutProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PutProductResult> Handle(PutProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new PutProductValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException($"Product not found");

        await _productRepository.DeleteByIdAsync(command.Id, cancellationToken);

        var result = new PutProductResult() { message = "successful deleted" };
        return result;
    }
}
