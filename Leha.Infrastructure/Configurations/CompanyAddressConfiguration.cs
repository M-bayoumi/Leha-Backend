using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class CompanyAddressConfiguration : IEntityTypeConfiguration<CompanyAddress>
{
    public void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.AddressAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AddressEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.ToTable("CompanyAddresses");
    }
}

