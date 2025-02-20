using Ambev.DeveloperEvaluation.Application.Sales.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSalesResult>();
        CreateMap<Domain.Entities.SaleProduct, GetSalesProductResult>();
    }
}
