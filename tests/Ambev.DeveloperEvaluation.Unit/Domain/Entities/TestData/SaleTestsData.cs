using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;


namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class SaleTestsData
{

    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.UserId, f => f.Random.Guid())
        .RuleFor(s => s.Branch, f => f.Random.String2(1, 10))
        .RuleFor(s => s.Cancelled, false)
        .RuleFor(s => s.SaleCreated, f => f.Date.Past())
        .RuleFor(s => s.SaleModified, f => f.Date.Past())
        .RuleFor(s => s.SaleCancelled, f => f.Date.Past())
        .RuleFor(s => s.SaleProducts, SaleProductFaker.Generate(3));

    private static readonly Faker<SaleProduct> SaleProductFaker = new Faker<SaleProduct>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.Quantity, f => f.Random.Number(1, 10))
        .RuleFor(s => s.Discounts, f => f.Random.Number(1, 10))
        .RuleFor(s => s.Product, ProductFaker.Generate());

    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.Title, f => f.Random.String2(1, 10))
        .RuleFor(s => s.Category, f => f.Random.String2(1, 10))
        .RuleFor(s => s.Description, f => f.Random.String2(1, 20))
        .RuleFor(s => s.Image, f => f.Random.String2(1, 10))
        .RuleFor(s => s.Price, f => f.Random.Decimal(1, 1000))
        .RuleFor(s => s.Rating, RatingFaker.Generate());


    private static readonly Faker<Rating> RatingFaker = new Faker<Rating>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.Rate, f => f.Random.Number(1, 5))
        .RuleFor(s => s.Count, f => f.Random.Number(1, 5));

    public static async Task<Sale> GenerateSale()
    {
        var sale = SaleFaker.Generate();
        await sale.CalculateAsync();
        return sale;
    }
}
