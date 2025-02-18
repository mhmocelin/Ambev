using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartProfile : Profile
{
    public DeleteCartProfile()
    {
        CreateMap<DeleteCartCommand, Domain.Entities.Cart>();
        CreateMap<Domain.Entities.Cart, DeleteCartResult>();
    }
}
