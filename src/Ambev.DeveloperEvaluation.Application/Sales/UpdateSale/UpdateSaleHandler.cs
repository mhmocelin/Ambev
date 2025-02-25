using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleCalculateService _saleCalculateService;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ISaleCalculateService saleCalculateService)
    {
        _saleRepository = saleRepository;
        _mapper = mapper; 
        _saleCalculateService = saleCalculateService;
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

        await _saleCalculateService.CalculateSaleTotalAsync(sale, cancellationToken);

        var saleUpdated = await _saleRepository.UpdateAsync(sale, cancellationToken);

        var result = _mapper.Map<UpdateSaleResult>(saleUpdated);
        return result;
    }
}
