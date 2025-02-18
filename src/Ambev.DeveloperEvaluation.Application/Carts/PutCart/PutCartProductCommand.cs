namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartProductCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
