using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullNameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.FullNameEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AddressAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AddressEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.JobTitleAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.JobTitleEn)
         .HasColumnType("Nvarchar(max)")
         .IsRequired();

        builder.Property(x => x.CV)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DateTime)
           .HasColumnType("datetime")
           .IsRequired();

        builder.ToTable("Forms");
    }
}
