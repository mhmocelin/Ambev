using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdCommand: IRequest<GetCartByIdResult>
    {
        public Guid Id { get; set; }

        public GetCartByIdCommand(Guid id) => this.Id = id;
    }
}
