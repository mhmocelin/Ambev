using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

public class GetProductsByCategoryCommand : IRequest<GetProductsByCategoryResult>
{
    public string Category { get; set; }

    public GetProductsByCategoryCommand(string category)
    {
        Category = category;
    }   
}
