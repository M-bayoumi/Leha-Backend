using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.FormFullName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.FormAddress)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.FormJobTitle)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.FormCV)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.FormDateTime)
           .HasColumnType("datetime")
           .IsRequired();


        builder.ToTable("Forms");
    }
}
