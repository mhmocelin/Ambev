using Ambev.DeveloperEvaluation.Application.Sales.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Domain.Entities.Sale>();
        CreateMap<BaseSaleProduct, Domain.Entities.SaleProduct>();
        CreateMap<Domain.Entities.Sale, CreateSaleResult>();
        CreateMap<Domain.Entities.SaleProduct, BaseSaleProduct>();
    }
}
