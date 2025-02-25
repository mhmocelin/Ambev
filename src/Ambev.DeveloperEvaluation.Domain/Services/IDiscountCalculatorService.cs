namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface IDiscountCalculatorService
{
    decimal CalculateDiscount(int quantity);
}
