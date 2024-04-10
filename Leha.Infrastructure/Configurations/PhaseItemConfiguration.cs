using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PhaseItemConfiguration : IEntityTypeConfiguration<PhaseItem>
{
    public void Configure(EntityTypeBuilder<PhaseItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.AcumulativePercentage)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.ProgressPercentage)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.ExecutionProgressAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ExecutionProgressEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.RFIAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.RFIEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.WIRAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.WIREn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ScheduleAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ScheduleEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.UnitAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.UnitEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.InitialInventoryQuantities)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.ActualInventoryQuantities)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.PercentageLossOrExceed)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.ToTable("PhaseItems");
    }
}
