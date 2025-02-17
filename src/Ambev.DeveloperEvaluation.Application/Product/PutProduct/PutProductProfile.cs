using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.PutProduct;

public class PutProductProfile : Profile
{
    public PutProductProfile()
    {
        CreateMap<PutProductCommand, Domain.Entities.Product>();
        CreateMap<Domain.Entities.Product, PutProductResult>();
    }
}
