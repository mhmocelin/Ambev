using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartProfile : Profile
{
    public PutCartProfile()
    {
        CreateMap<PutCartCommand, Domain.Entities.Cart>();
        CreateMap<PutCartProductCommand, Domain.Entities.CartProduct>();
        CreateMap<Domain.Entities.Cart, PutCartResult>();
        CreateMap<Domain.Entities.CartProduct, PutCartProductResult>();
    }
}
