using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;

public class GetCartByIdResponse : BaseCart
{
    public Guid Id { get; set; }
}
