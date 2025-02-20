using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequest : IRequest<GetSaleCommand>
{
    public Guid Id { get; set; }
    public GetSaleRequest(Guid Id) => this.Id = Id;
}
