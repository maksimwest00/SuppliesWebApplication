using Microsoft.EntityFrameworkCore;
using SuppliesWebApplication.Application.Offers;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Infrastructure.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OffersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOffer(
            Offer offer,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Offers.AddAsync(offer, cancellationToken);

            return offer.Id;
        }

        public async Task<List<Offer>> Find(
            FindOffersRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request.Stamp is null &&
                request.Model is null &&
                request.SupplierId is null)
            {
                return await _dbContext.Offers
                    .Include(x => x.Supplier)
                    .ToListAsync(cancellationToken);
            }

            return await _dbContext.Offers
                .Where(x => x.Stamp == request.Stamp &&
                            x.Model == request.Model &&
                            x.SupplierId == request.SupplierId)
                .Include(x => x.Supplier)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<MostPopularSuppliersResponse>> MostPopularSuppliers(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Offers
                        .GroupBy(x => x.SupplierId)
                        .OrderByDescending(x => x.Count())
                        .Select(g =>
                        new MostPopularSuppliersResponse(g.First().Supplier!.Name!, g.Count()))
                        .Take(3)
                        .ToListAsync(cancellationToken);
        }
    }
}
