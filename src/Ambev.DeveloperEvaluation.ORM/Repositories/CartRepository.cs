using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context) => _context = context;

    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    public async Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.Carts.Include(c => c.Products).ToListAsync();

    public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.UserId == userId);

    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }
    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken)
    {
        var entity = await _context.Carts.FirstOrDefaultAsync(p => p.Id == cart.Id);

        if (entity != null)
            entity.Products = cart.Products;

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (cart == null)
            return await Task.FromResult(false);

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return await Task.FromResult(true);
    }
}
