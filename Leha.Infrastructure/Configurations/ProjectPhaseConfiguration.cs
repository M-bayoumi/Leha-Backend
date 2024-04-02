using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class ProjectPhaseConfiguration : IEntityTypeConfiguration<ProjectPhase>
{
    public void Configure(EntityTypeBuilder<ProjectPhase> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ProjectPhaseName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.HasMany(x => x.PhaseItems)
           .WithOne(x => x.ProjectPhase)
           .HasForeignKey(x => x.ProjectPhaseID)
           .IsRequired();

        builder.ToTable("ProjectPhases");
    }
}
