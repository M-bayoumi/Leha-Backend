using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class HomeImageConfiguration : IEntityTypeConfiguration<HomeImage>
{
    public void Configure(EntityTypeBuilder<HomeImage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ImageURL)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.ToTable("HomeImages");
    }
}
