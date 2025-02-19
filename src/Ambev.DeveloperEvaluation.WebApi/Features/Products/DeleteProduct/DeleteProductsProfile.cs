using Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

public class DeleteUserProfile : Profile
{
    public DeleteUserProfile()
    {
        CreateMap<Guid, DeleteProductCommand>()
            .ConstructUsing(id => new DeleteProductCommand(id));
    }
}
