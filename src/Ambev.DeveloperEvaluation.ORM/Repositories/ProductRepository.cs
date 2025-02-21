using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context) => _context = context;

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Products
                        .Include(c => c.Rating)
                        .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
            => await _context.Products.Include(c => c.Rating).ToListAsync();

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken)
            => await _context.Products
                .Include(c => c.Rating)
                .Where(p => p.Category == category)
                .ToListAsync();

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            _context.Ratings.Update(product.Rating);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (product == null)
                return await Task.FromResult(false);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
    }
}
