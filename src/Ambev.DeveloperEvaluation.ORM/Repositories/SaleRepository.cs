using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context) => _context = context;

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }
    
    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (sale == null)
            return await Task.FromResult(false);

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return await Task.FromResult(true);
    }

    public async Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.Sales.Include(c => c.SaleProducts).ToListAsync();
   
    public async Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Sales
                         .Include(c => c.SaleProducts)
                         .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }
}
