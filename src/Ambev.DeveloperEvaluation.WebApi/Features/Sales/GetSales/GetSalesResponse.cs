﻿using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSalesResponse : BaseSale
{
    public Guid Id {  get; set; }
    public int SaleNumber { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public bool Cancelled { get; set; }
    public DateTime? SaleCreated { get; set; }
    public DateTime? SaleModified { get; set; }
    public DateTime? SaleCancelled { get; set; }
    public List<GetSalesProductResponse> SaleProducts { get; set; }
}
