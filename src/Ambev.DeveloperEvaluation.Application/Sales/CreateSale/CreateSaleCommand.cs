using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : BaseSale, IRequest<CreateSaleResult>
{
}
