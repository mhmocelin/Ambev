using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductsProfile : Profile
{
    public GetProductsProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductsResult>();
    }
}
