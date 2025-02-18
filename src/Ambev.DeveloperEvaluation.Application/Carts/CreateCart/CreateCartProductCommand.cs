namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProductCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
