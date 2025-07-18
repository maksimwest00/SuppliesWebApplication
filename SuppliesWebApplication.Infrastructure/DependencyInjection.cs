using Microsoft.Extensions.DependencyInjection;
using SuppliesWebApplication.Application.Offers;
using SuppliesWebApplication.Application.Suppliers;
using SuppliesWebApplication.Infrastructure.Repositories;

namespace SuppliesWebApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IOffersRepository, OffersRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();

            return services;
        }
    }
}
