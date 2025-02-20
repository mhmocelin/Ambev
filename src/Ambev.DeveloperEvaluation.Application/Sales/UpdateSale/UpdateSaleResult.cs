using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public  class UpdateSaleResult : BaseSale, IRequest<UpdateSaleCommand>
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public bool Cancelled { get; set; }
    public DateTime? SaleCreated { get; set; }
    public DateTime? SaleModified { get; set; }
    public DateTime? SaleCancelled { get; set; }
}
