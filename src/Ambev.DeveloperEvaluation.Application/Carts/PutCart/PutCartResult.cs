namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<PutCartProductResult> Products { get; set; }
}
