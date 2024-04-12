using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.SloganAr)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.SloganEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();


        builder.Property(x => x.Employees)
           .HasColumnType("int")
           .IsRequired();

        builder.Property(x => x.Image)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.Email)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.Phone)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.Link)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.HasMany(x => x.Services)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Services)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Products)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.HomeImages)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.CompanyAddresses)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Posts)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Jobs)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Clients)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();

        builder.HasMany(x => x.Projects)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyId)
           .IsRequired();


        builder.ToTable("Companies");
        //builder.ToTable("Companies", schema: "YourSchemaName");

    }
}
