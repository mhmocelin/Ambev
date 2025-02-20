using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.PutCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.PutCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

public class CartsProfiles : Profile
{
    public CartsProfiles()
    {
        CreateMap<GetCartResult, GetCartResponse>();
        CreateMap<GetCartProductResult, BaseCartProduct>();
        
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<BaseCartProduct, CreateCartProductCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>();
        CreateMap<CreateCartProductResult, BaseCartProduct>();

        CreateMap<Guid, GetCartByIdCommand>()
           .ConstructUsing(id => new GetCartByIdCommand(id));

        CreateMap<GetCartByIdResult, GetCartByIdResponse>();
        CreateMap<GetCartByIdProductResult, BaseCartProduct>();

        CreateMap<Guid, DeleteCartCommand>()
           .ConstructUsing(id => new DeleteCartCommand(id));

        CreateMap<PutCartRequest, PutCartCommand>();
        CreateMap<BaseCartProduct, PutCartProductCommand>();
        CreateMap<PutCartResult, PutCartResponse>();
        CreateMap<PutCartProductResult, BaseCartProduct>();


    }
}
