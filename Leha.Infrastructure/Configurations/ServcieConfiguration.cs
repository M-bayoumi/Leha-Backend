using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ServcieConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
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

        builder.ToTable("Servcies");
    }
}