using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductsByCategoryProfile : Profile
{
    public GetProductsByCategoryProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductsByCategoryResult>();
    }
}
