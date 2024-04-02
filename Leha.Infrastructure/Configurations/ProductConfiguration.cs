using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ProductName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ProductDescription)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ProductImage)
           .HasColumnType("varchar(max)")
           .IsRequired();


        builder.ToTable("Products");
    }
}