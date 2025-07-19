using CSharpFunctionalExtensions;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Application.Offers
{
    public class FindOffersHandler(IOffersRepository offersRepository)
    {
        public async Task<Result<IReadOnlyList<Offer>, string>> Handle(
            FindOffersRequest request,
            CancellationToken cancellationToken = default)
        {
            var offers = await offersRepository.Find(
                request,
                cancellationToken);

            if (offers.Count is 0)
                return "Offers not found";

            return offers;
        }
    }
}
