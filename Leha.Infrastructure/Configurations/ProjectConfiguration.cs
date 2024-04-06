using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ProjectName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ProjectDescription)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ProjectAddress)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ProjectImage)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.SiteEngineerName)
          .HasColumnType("varchar(max)")
          .IsRequired();


        builder.Property(x => x.ProjectProgressPercentage)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        //builder.HasCheckConstraint("CK_ProjectProgressPercentage", "ProjectProgressPercentage >= 0 AND ProjectProgressPercentage <= 100.00");

        builder.HasMany(x => x.ProjectPhases)
           .WithOne(x => x.Project)
           .HasForeignKey(x => x.ProjectID)
           .IsRequired();


        builder.ToTable("Projects");
    }
}