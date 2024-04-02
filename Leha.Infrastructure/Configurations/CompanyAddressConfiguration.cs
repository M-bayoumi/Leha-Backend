using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class CompanyAddressConfiguration : IEntityTypeConfiguration<CompanyAddress>
{
    public void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.Address)
           .HasColumnType("varchar(max)")
           .IsRequired();


        builder.ToTable("CompanyAddresses");
    }
}

