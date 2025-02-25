using Ambev.DeveloperEvaluation.Application.Service;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using NSubstitute;
using Xunit;


namespace Ambev.DeveloperEvaluation.Unit.Application

{
    public class SaleCalculateServiceTests
    {
        private readonly IProductRepository _productRepositoryMock;
        private readonly IDiscountCalculatorService _discountCalculatorServiceMock;
        private readonly SaleCalculateService _saleCalculateService;

        public SaleCalculateServiceTests()
        {
            _productRepositoryMock = Substitute.For<IProductRepository>();
            _discountCalculatorServiceMock = Substitute.For<IDiscountCalculatorService>();
            _saleCalculateService = new SaleCalculateService(
                _productRepositoryMock,
                _discountCalculatorServiceMock
            );
        }

        [Fact]
        public async Task CalculateSaleTotalAsync_ShouldCalculateTotalCorrectly()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Title = "Product A",
                Price = 100.00m
            };

            var sale = new Sale
            {
                SaleProducts = new List<SaleProduct>
                {
                    new SaleProduct
                    {
                        ProductId = productId,
                        Quantity = 2
                    }
                }
            };

            _productRepositoryMock
                .GetByIdAsync(productId, Arg.Any<CancellationToken>())
                .Returns(product);

            _discountCalculatorServiceMock
                .CalculateDiscount(Arg.Any<int>())
                .Returns(10); // 10% de desconto

            // Act
            await _saleCalculateService.CalculateSaleTotalAsync(sale, CancellationToken.None);

            // Assert
            Assert.Equal(180.00m, sale.TotalSaleAmount); // 2 * (100 - (100 * 0.10)) = 180
            Assert.Equal(100.00m, sale.SaleProducts.FirstOrDefault().UnitPrice);
            Assert.Equal(10, sale.SaleProducts.FirstOrDefault().Discounts);
            Assert.Equal(180.00m, sale.SaleProducts.FirstOrDefault().TotalAmount);
        }

        [Fact]
        public async Task CalculateSaleTotalAsync_ShouldHandleMultipleProducts()
        {
            // Arrange
            var productId1 = Guid.NewGuid();
            var productId2 = Guid.NewGuid();

            var product1 = new Product
            {
                Id = productId1,
                Title = "Product A",
                Price = 100.00m
            };

            var product2 = new Product
            {
                Id = productId2,
                Title = "Product B",
                Price = 50.00m
            };

            var sale = new Sale
            {
                SaleProducts = new List<SaleProduct>
                {
                    new SaleProduct { ProductId = productId1, Quantity = 2 },
                    new SaleProduct { ProductId = productId2, Quantity = 3 }
                }
            };

            _productRepositoryMock
                .GetByIdAsync(productId1, Arg.Any<CancellationToken>())
                .Returns(product1);

            _productRepositoryMock
                .GetByIdAsync(productId2, Arg.Any<CancellationToken>())
                .Returns(product2);

            _discountCalculatorServiceMock
                .CalculateDiscount(Arg.Any<int>())
                .Returns(10); // 10% de desconto

            // Act
            await _saleCalculateService.CalculateSaleTotalAsync(sale, CancellationToken.None);

            // Assert
            Assert.Equal(315.00m, sale.TotalSaleAmount); // (2 * 90) + (3 * 45) = 180 + 135 = 315
        }

        [Fact]
        public async Task CalculateSaleTotalAsync_ShouldHandleZeroDiscount()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Title = "Product A",
                Price = 100.00m
            };

            var sale = new Sale
            {
                SaleProducts = new List<SaleProduct>
                {
                    new SaleProduct { ProductId = productId, Quantity = 2 }
                }
            };

            _productRepositoryMock
                .GetByIdAsync(productId, Arg.Any<CancellationToken>())
                .Returns(product);

            _discountCalculatorServiceMock
                .CalculateDiscount(Arg.Any<int>())
                .Returns(0); // 0% de desconto

            // Act
            await _saleCalculateService.CalculateSaleTotalAsync(sale, CancellationToken.None);

            // Assert
            Assert.Equal(200.00m, sale.TotalSaleAmount); // 2 * 100 = 200
        }
    }
}