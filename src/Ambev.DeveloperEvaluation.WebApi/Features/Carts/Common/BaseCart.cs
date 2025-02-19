namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

public class BaseCart
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<BaseCartProduct> Products { get; set; }
}
