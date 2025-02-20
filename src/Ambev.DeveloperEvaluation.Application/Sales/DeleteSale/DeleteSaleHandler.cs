using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
{
    private readonly ISaleRepository _SaleRepository;
    private readonly IMapper _mapper;

    public DeleteSaleHandler(ISaleRepository SaleRepository, IMapper mapper)
    {
        _SaleRepository = SaleRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSaleResult> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Sale = await _SaleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (Sale == null)
            throw new KeyNotFoundException($"Sale not found");

        await _SaleRepository.DeleteByIdAsync(command.Id, cancellationToken);

        return new DeleteSaleResult() { message = "successful deleted" };
    }
}
