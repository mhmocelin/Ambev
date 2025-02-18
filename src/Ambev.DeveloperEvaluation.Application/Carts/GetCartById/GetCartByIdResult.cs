namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById;

public class GetCartByIdResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<GetCartByIdProductResult> Products { get; set; }
}
