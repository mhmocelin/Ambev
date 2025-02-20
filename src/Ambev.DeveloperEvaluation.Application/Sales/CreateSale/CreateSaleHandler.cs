using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Domain.Entities.Sale>(command);

        foreach (var item in sale.SaleProducts)
        {
            item.Product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
        }

        await sale.CalculateAsync();

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
