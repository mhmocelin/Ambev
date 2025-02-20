namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesRequest
{
    public Guid Id { get; set; }
    public GetSalesRequest(Guid Id) => this.Id = Id;
}
