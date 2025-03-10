﻿using Ambev.DeveloperEvaluation.Application.Sales.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.SaleProduct, GetSaleProductResult>();
        CreateMap<Domain.Entities.Sale, GetSaleResult>();
    }
}
