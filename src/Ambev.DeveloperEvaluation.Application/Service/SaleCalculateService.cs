using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Service;

public class SaleCalculateService : ISaleCalculateService
{
    private readonly IProductRepository _productRepository;
    private readonly IDiscountCalculatorService _discountCalculatorService;
    public SaleCalculateService(IProductRepository productRepository, IDiscountCalculatorService discountCalculatorService)
    {
        _productRepository = productRepository;
        _discountCalculatorService = discountCalculatorService;
    }
    public async Task CalculateSaleTotalAsync(Sale sale, CancellationToken cancellationToken)
    {
        foreach (var item in sale.SaleProducts)
        {
            item.Product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
            item.Discounts = _discountCalculatorService.CalculateDiscount(item.Quantity);
            item.UnitPrice = item.Product.Price;
            item.TotalAmount = item.Quantity * (item.UnitPrice - (item.UnitPrice * (item.Discounts / 100)));
        }

        sale.TotalSaleAmount = sale.SaleProducts.Sum(x => x.TotalAmount);
    }
}
