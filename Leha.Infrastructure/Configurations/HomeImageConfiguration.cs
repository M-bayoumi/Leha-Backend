using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations
{
    public class HomeImageConfiguration : IEntityTypeConfiguration<HomeImage>
    {
        public void Configure(EntityTypeBuilder<HomeImage> builder)
        {
            builder.HasKey(x => x.ID);

            //builder.Property(x => x.HomeImageBytes)
            //   .HasColumnType("binary(max)")
            //   .IsRequired();

            builder.ToTable("HomeImages");
        }
    }
}
