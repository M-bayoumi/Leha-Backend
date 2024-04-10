using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.DescriptionAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DescriptionEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.Image)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.ToTable("Products");
    }
}