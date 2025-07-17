using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuppliesWebApplication.Domain.Entities;
using SuppliesWebApplication.Domain.Shared;

namespace SuppliesWebApplication.Infrastructure.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("offers");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Stamp)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("stamp");

            builder.Property(o => o.Model)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("model");

            builder.HasOne(o => o.Provider);

            builder.Property(o => o.DateRegistration)
                   .IsRequired();
        }
    }
}
