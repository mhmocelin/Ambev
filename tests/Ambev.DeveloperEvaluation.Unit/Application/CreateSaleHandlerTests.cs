using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();

        _handler = new CreateSaleHandler(_saleRepository, _mapper, _productRepository);
    }

    [Fact]
    public async Task Handle_ShouldCreateSaleSuccessfully()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Curitiba",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>
            {
                new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 5 }
            }
        };

        var sale = new Sale
        {
            UserId = command.UserId,
            Branch = "Curitiba",
            Date = DateTime.UtcNow,
            SaleProducts = new List<SaleProduct>
            {
                new SaleProduct { ProductId = command.SaleProducts.FirstOrDefault().ProductId, Quantity = 5 }
            }
        };

        var product = new Product { Id = sale.SaleProducts.FirstOrDefault().ProductId, Price = 100m };

        _mapper.Map<Sale>(command).Returns(sale);
        _productRepository.GetByIdAsync(product.Id, Arg.Any<CancellationToken>()).Returns(Task.FromResult(product));
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(sale));
        _mapper.Map<CreateSaleResult>(sale).Returns(new CreateSaleResult());

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        await _productRepository.Received(1).GetByIdAsync(product.Id, Arg.Any<CancellationToken>());
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
    {
        // Arrange
        var command = new CreateSaleCommand(); // Comando inválido (sem produtos)

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldFetchProductsBeforeCalculatingTotal()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Curitiba",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>
            {
                new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 5 }
            }
        };

        var sale = new Sale
        {
            UserId = command.UserId,
            Branch = "Curitiba",
            Date = DateTime.UtcNow,
            SaleProducts = new List<SaleProduct>
            {
                new SaleProduct { ProductId = command.SaleProducts.FirstOrDefault().ProductId, Quantity = 5 }
            }
        };

        var product = new Product { Id = sale.SaleProducts.FirstOrDefault().ProductId, Price = 100m };

        _mapper.Map<Sale>(command).Returns(sale);
        _productRepository.GetByIdAsync(product.Id, Arg.Any<CancellationToken>()).Returns(Task.FromResult(product));

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _productRepository.Received(1).GetByIdAsync(product.Id, Arg.Any<CancellationToken>());
    }
}