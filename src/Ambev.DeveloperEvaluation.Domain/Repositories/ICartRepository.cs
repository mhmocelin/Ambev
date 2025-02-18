using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken);
        Task<Cart> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken);
        Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
