using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken);
    Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Sale> UpdateAsync(Sale saleToUpdate, CancellationToken cancellationToken);
}
