using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

public class CartsProfiles : Profile
{
    public CartsProfiles()
    {
        CreateMap<GetCartResult, GetCartResponse>();

        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>();

        CreateMap<GetCartByIdResult, GetCartByIdResponse>();

        CreateMap<Guid, DeleteCartCommand>()
           .ConstructUsing(id => new DeleteCartCommand(id));

    }
}
