using Microsoft.EntityFrameworkCore;
using SuppliesWebApplication.Application.Suppliers;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SuppliersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier?> GetSupplierById(int supplierId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Suppliers
                .FirstOrDefaultAsync(x => x.Id == supplierId, cancellationToken);
        }
    }
}
