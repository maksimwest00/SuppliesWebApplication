using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Application.Suppliers
{
    public interface ISuppliersRepository
    {
        Task<Supplier?> GetSupplierById(
            int supplierId,
            CancellationToken cancellationToken = default);
    }
}