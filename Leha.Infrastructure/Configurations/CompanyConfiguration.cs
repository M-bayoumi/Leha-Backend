using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.CompanyName)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.ToTable("Companies");
        }
    }
}
