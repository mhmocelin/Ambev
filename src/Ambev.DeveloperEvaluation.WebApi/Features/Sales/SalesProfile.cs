using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.PutSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class SalesProfile : Profile
{
    public SalesProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<Common.BaseSaleProduct, BaseSaleProduct>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<BaseSaleProduct, Common.BaseSaleProduct>();

        CreateMap<Guid, GetSaleCommand>()
            .ConstructUsing(id => new GetSaleCommand(id));
        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleProductResult, GetSaleProductResponse>();

        CreateMap<GetSalesResult, GetSalesResponse>();
        CreateMap<GetSalesProductResult, GetSalesProductResponse>();

        CreateMap<PutSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleResult, PutSaleResponse>();
        CreateMap<UpdateSaleProductResult, PutSaleProductResponse>();

        CreateMap<Guid, DeleteSaleCommand>()
            .ConstructUsing(id => new DeleteSaleCommand(id));

    }
}
