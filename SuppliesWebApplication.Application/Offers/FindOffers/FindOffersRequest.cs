namespace SuppliesWebApplication.Application.Offers
{
    public record FindOffersRequest(string? Stamp,
                                    string? Model,
                                    int? SupplierId);
}
