using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
    [Fact]
    public async Task CalculateAsync_ShouldCalculateTotalSaleAmountCorrectly()
    {
        // Arrange
        var sale = new Sale
        {
            SaleProducts = new List<SaleProduct>
            {
                new SaleProduct
                {
                    Quantity = 5, // Deve aplicar desconto de 10%
                    Product = new Product { Price = 100m }
                },
                new SaleProduct
                {
                    Quantity = 10, // Deve aplicar desconto de 20%
                    Product = new Product { Price = 200m }
                }
            }
        };

        // Act
        await sale.CalculateAsync();

        // Assert
        decimal expectedTotal = (5 * (100 - (100 * 0.10m))) + (10 * (200 - (200 * 0.20m)));
        Assert.Equal(expectedTotal, sale.TotalSaleAmount);
    }

    [Theory]
    [InlineData(3, 0)]   // Quantidade 3 -> Sem desconto
    [InlineData(4, 10)]  // Quantidade 4 -> 10% de desconto
    [InlineData(10, 20)] // Quantidade 10 -> 20% de desconto
    public async Task CalculateAsync_ShouldApplyCorrectDiscount(int quantity, decimal expectedDiscount)
    {
        // Arrange
        var sale = new Sale
        {
            SaleProducts = new List<SaleProduct>
            {
                new SaleProduct
                {
                    Quantity = quantity,
                    Product = new Product { Price = 50m }
                }
            }
        };

        // Act
        await sale.CalculateAsync();

        // Assert
        Assert.Equal(expectedDiscount, sale.SaleProducts.First().Discounts);
    }

    [Fact]
    public async Task CalculateAsync_WithNoProducts_ShouldNotThrowException()
    {
        // Arrange
        var sale = new Sale { SaleProducts = new List<SaleProduct>() };

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => sale.CalculateAsync());
        Assert.Null(exception);
        Assert.Equal(0, sale.TotalSaleAmount);
    }
}
