using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleCalculateService
{
    Task CalculateSaleTotalAsync(Sale sale, CancellationToken cancellationToken);
}
