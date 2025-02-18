using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartCommand : IRequest<PutCartResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<PutCartProductCommand> Products { get; set; }
}
