using CSharpFunctionalExtensions;
using SuppliesWebApplication.Application.Suppliers;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Application.Offers
{
    public class CreateOfferHandler(IOffersRepository offersRepository, ISuppliersRepository suppliersRepository)
    {
        public async Task<Result<int, string>> Handle(
                CreateOfferRequest request,
                CancellationToken cancellationToken = default)
        {

            var offers = await offersRepository.Find(
                new FindOffersRequest(request.Stamp,
                                      request.Model,
                                      request.SupplierId),
                cancellationToken);

            if (offers.Count > 0)
                return "Offer already exist";


            var supplier = await suppliersRepository.GetSupplierById(request.SupplierId,
                                                                     cancellationToken);

            if (supplier is null)
                return "Supplier not found";

            var offer = Offer.Create(request.Stamp,
                                     request.Model,
                                     supplier);

            return await offersRepository.CreateOffer(offer, cancellationToken);
        }
    }
}
