﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public  class GetSalesHandler : IRequestHandler<GetSalesCommand, IEnumerable<GetSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetSalesResult>> Handle(GetSalesCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetAllAsync(cancellationToken);
        if (!sale.Any())
            throw new KeyNotFoundException($"Sales not found");

        var result = _mapper.Map<IEnumerable<GetSalesResult>>(sale);
        return result;
    }
}
