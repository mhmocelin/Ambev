namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommand
{
    public Guid Id { get; set; }
    public GetSaleCommand(Guid id) => this.Id = id;
}
