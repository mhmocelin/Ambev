using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById;

public class GetCartByIdProfile : Profile
{
    public GetCartByIdProfile()
    {
        CreateMap<GetCartByIdCommand, Domain.Entities.Cart>();
        CreateMap<Domain.Entities.Cart, GetCartByIdResult>();
    }
}
