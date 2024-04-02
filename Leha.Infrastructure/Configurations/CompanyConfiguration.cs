using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.CompanyName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.CompanyEmployees)
           .HasColumnType("int")
           .IsRequired();

        builder.Property(x => x.CompanyImage)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.CompanyEmail)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.CompanyPhone)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.HasMany(x => x.Services)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Services)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Products)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.HomeImages)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.CompanyAddresses)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Posts)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Jobs)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Clients)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();

        builder.HasMany(x => x.Projects)
           .WithOne(x => x.Company)
           .HasForeignKey(x => x.CompanyID)
           .IsRequired();


        builder.ToTable("Companies");
    }
}
