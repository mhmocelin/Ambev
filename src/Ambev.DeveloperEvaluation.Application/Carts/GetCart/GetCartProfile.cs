using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<GetCartCommand, Domain.Entities.Cart>();
        CreateMap<Domain.Entities.Cart, GetCartResult>();
        CreateMap<Domain.Entities.CartProduct, GetCartProductResult>();
    }
}
