using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

public class GetProductsCommand : IRequest<IEnumerable<GetProductsResult>>
{
}
