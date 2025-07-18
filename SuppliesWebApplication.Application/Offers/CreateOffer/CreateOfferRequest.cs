namespace SuppliesWebApplication.Application.Offers
{
    public record CreateOfferRequest(string Stamp,
                                     string Model,
                                     int SupplierId);
}
