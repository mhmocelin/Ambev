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
            => await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
            => await _context.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken)
            => await _context.Products.Where(p => p.Category == category).ToListAsync();

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (entity != null)
            {
                entity.Title = product.Title;
                entity.Description = product.Description;
                entity.Category = product.Category;
                entity.Quantity = product.Quantity;
                entity.Price = product.Price;
                entity.Image = product.Image;
                entity.Rating = product.Rating;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
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
