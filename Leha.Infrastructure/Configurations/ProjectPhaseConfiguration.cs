using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ProjectPhaseConfiguration : IEntityTypeConfiguration<ProjectPhase>
{
    public void Configure(EntityTypeBuilder<ProjectPhase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.HasMany(x => x.PhaseItems)
           .WithOne(x => x.ProjectPhase)
           .HasForeignKey(x => x.ProjectPhaseId)
           .IsRequired();

        builder.ToTable("ProjectPhases");
    }
}
