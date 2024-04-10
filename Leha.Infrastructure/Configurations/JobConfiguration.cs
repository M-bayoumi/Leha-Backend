using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TitleAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.TitleEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.DescriptionAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DescriptionEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.AverageSalary)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DateTime)
           .HasColumnType("datetime")
           .IsRequired();

        builder.HasMany(x => x.Forms)
           .WithOne(x => x.Job)
           .HasForeignKey(x => x.JobId)
           .IsRequired();

        builder.ToTable("Jobs");
    }
}