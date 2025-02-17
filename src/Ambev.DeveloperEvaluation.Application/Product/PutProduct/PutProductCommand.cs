using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.PutProduct;

public class PutProductCommand : IRequest<PutProductResult>
{
    public Guid Id { get; set; }
    public PutProductCommand(Guid id) => Id = id;
}
