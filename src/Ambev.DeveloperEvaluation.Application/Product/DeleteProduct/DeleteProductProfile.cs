using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<DeleteProductCommand, Domain.Entities.Product>();
        CreateMap<Domain.Entities.Product, DeleteProductResult>();
    }
}
