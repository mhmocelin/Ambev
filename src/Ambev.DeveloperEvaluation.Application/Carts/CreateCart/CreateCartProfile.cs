using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile() 
    {
        CreateMap<CreateCartCommand, Domain.Entities.Cart>();
        CreateMap<Domain.Entities.Cart, CreateCartResult>();
        CreateMap<CreateCartProductCommand, Domain.Entities.CartProduct>();
        CreateMap<Domain.Entities.CartProduct, CreateCartProductResult>();
    }
}
