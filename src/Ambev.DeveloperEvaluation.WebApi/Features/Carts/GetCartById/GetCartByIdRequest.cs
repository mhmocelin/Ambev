namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;

public class GetCartByIdRequest
{
    public Guid Id { get; set; }

    public GetCartByIdRequest(Guid id) => this.Id = id;
}
