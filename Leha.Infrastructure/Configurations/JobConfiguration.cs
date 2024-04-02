using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.JobTitle)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.JobDescription)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.JobAverageSalary)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.JobDateTime)
           .HasColumnType("datetime")
           .IsRequired();

        builder.HasMany(x => x.Forms)
           .WithOne(x => x.Job)
           .HasForeignKey(x => x.JobID)
           .IsRequired();


        builder.ToTable("Jobs");
    }
}