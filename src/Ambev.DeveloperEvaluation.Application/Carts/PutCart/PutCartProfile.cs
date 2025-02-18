using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartProfile : Profile
{
    public PutCartProfile()
    {
        CreateMap<PutCartCommand, Domain.Entities.Cart>();
        CreateMap<Domain.Entities.Cart, PutCartResult>();
    }
}
