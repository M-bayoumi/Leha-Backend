using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ClientNameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ClientNameEn)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ClientImage)
           .HasColumnType("varchar(max)")
           .IsRequired();


        builder.ToTable("Clients");
    }
}
