using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<GetProductsCommand, Domain.Entities.Product>();
        CreateMap<Domain.Entities.Product, GetProductsResult>();
        CreateMap<Domain.Entities.Rating, GetRatingResult>();
    }
}
