using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ServcieConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ServiceName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ServiceDescription)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ServiceImage)
           .HasColumnType("varchar(max)")
           .IsRequired();


        builder.ToTable("Servcies");
    }
}