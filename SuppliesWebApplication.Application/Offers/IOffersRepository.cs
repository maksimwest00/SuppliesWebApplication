using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Application.Offers
{
    public interface IOffersRepository
    {
        Task<int> CreateOffer(
            Offer offer,
            CancellationToken cancellationToken = default);

        Task<List<Offer>> Find(
            FindOffersRequest supplierDto,
            CancellationToken cancellationToken = default);

        Task<List<MostPopularSuppliersResponse>> MostPopularSuppliers(
            CancellationToken cancellationToken = default);
    }
}
