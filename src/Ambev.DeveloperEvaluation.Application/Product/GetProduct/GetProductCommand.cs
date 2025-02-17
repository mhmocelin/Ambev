using MediatR;
using Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductCommand : IRequest<GetProductResult>
{
    public Guid Id { get; set; }

    public GetProductCommand(Guid id) => this.Id = id;
}
