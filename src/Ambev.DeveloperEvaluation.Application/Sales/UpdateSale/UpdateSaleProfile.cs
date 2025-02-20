using Ambev.DeveloperEvaluation.Application.Sales.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Domain.Entities.Sale>();
        CreateMap<BaseSaleProduct, Domain.Entities.SaleProduct>();
        CreateMap<Domain.Entities.Sale, UpdateSaleResult>();
        CreateMap<Domain.Entities.SaleProduct, BaseSaleProduct>();
    }
}
