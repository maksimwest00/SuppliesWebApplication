using Microsoft.Extensions.DependencyInjection;
using SuppliesWebApplication.Application.Offers;

namespace SuppliesWebApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<CreateOfferHandler>();
            services.AddScoped<FindOffersHandler>();
            services.AddScoped<MostPopularSuppliersHandler>();

            return services;
        }
    }
}
