﻿namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

public class BaseSale
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public IEnumerable<BaseSaleProduct>? SaleProducts { get; set; }
}
