using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.DescriptionAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DescriptionEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AddressAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AddressEn)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.Image)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.SiteEngineerNameAr)
          .HasColumnType("Nvarchar(max)")
          .IsRequired();

        builder.Property(x => x.SiteEngineerNameEn)
         .HasColumnType("Nvarchar(max)")
         .IsRequired();

        builder.Property(x => x.ProjectProgressPercentage)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.HasMany(x => x.ProjectPhases)
           .WithOne(x => x.Project)
           .HasForeignKey(x => x.ProjectId)
           .IsRequired();

        builder.ToTable("Projects");
    }
}