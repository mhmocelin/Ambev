using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Service;

public class DiscountCalculatorService : IDiscountCalculatorService
{
    public decimal CalculateDiscount(int quantity)
    {
        switch (quantity)
        {
            case >= 10:
                return 20;
            case >= 4:
                return 10;
            default:
                return 0;
        }
    }
}
