using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException($"Sale not found");

        var saleToUpdate = _mapper.Map<Domain.Entities.Sale>(command);

        foreach (var item in saleToUpdate.SaleProducts)
        {
            item.Product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
        }
        await saleToUpdate.CalculateAsync();
        sale.Update(saleToUpdate);

        var saleUpdated = await _saleRepository.UpdateAsync(sale, cancellationToken);

        var result = _mapper.Map<UpdateSaleResult>(saleUpdated);
        return result;
    }
}
