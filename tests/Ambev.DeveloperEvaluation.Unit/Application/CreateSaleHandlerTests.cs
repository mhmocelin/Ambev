using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepositoryMock;
    private readonly IMapper _mapperMock;
    private readonly ISaleCalculateService _saleCalculateServiceMock;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepositoryMock = Substitute.For<ISaleRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _saleCalculateServiceMock = Substitute.For<ISaleCalculateService>();
        _handler = new CreateSaleHandler(_saleRepositoryMock, _mapperMock, _saleCalculateServiceMock);
    }

    [Fact]
    public async Task Handle_ShouldMapCommandToSaleEntity()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Branch A",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>()
                {
                    new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
        };

        var sale = new Sale();
        _mapperMock.Map<Sale>(command).Returns(sale);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mapperMock.Received(1).Map<Sale>(command);
    }

    [Fact]
    public async Task Handle_ShouldCallCalculateSaleTotalAsync()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Branch A",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>
                {
                    new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
        };

        var sale = new Sale();
        _mapperMock.Map<Sale>(command).Returns(sale);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _saleCalculateServiceMock.Received(1).CalculateSaleTotalAsync(sale, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldCallCreateAsyncOnRepository()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Branch A",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>
                {
                    new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
        };

        var sale = new Sale();
        _mapperMock.Map<Sale>(command).Returns(sale);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _saleRepositoryMock.Received(1).CreateAsync(sale, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldMapCreatedSaleToResult()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            UserId = Guid.NewGuid(),
            Branch = "Branch A",
            Date = DateTime.UtcNow,
            SaleProducts = new List<BaseSaleProduct>
                {
                    new BaseSaleProduct { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
        };

        var sale = new Sale();
        var createdSale = new Sale { Id = Guid.NewGuid() };
        var result = new CreateSaleResult { Id = createdSale.Id };

        _mapperMock.Map<Sale>(command).Returns(sale);
        _saleRepositoryMock.CreateAsync(sale, Arg.Any<CancellationToken>()).Returns(createdSale);
        _mapperMock.Map<CreateSaleResult>(createdSale).Returns(result);

        // Act
        var handlerResult = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(result.Id, handlerResult.Id);
        _mapperMock.Received(1).Map<CreateSaleResult>(createdSale);
    }
}