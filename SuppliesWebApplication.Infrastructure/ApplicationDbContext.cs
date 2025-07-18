using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        private const string DATABASE = "Database";

        public DbSet<Offer> Offers => Set<Offer>();

        public DbSet<Supplier> Suppliers => Set<Supplier>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var dateTime = new DateTime(2025, 7, 17, 16, 40, 17, DateTimeKind.Local);

            var suppliers = new List<Supplier>()
            {
                new Supplier ("Поставщик 1", dateTime) { Id = 1 },
                new Supplier ("Поставщик 2", dateTime) { Id = 2 },
                new Supplier ("Поставщик 3", dateTime) { Id = 3 },
                new Supplier ("Поставщик 4", dateTime) { Id = 4 },
                new Supplier ("Поставщик 5", dateTime) { Id = 5 },
            };
            modelBuilder.Entity<Supplier>().HasData(suppliers);

            var offers = new List<Offer>();
            for (int i = 1, j = 1; i <= 15; i++)
            {
                var tmpOffer = new Offer($"Марка {i}", $"Модель {i}", dateTime) { Id = i, SupplierId = j };
                offers.Add(tmpOffer);
                j++;
                if (j > 5)
                {
                    j = 1;
                }
            }
            modelBuilder.Entity<Offer>().HasData(offers);
        }


        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
