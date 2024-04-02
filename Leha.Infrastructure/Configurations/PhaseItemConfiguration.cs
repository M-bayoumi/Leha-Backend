using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PhaseItemConfiguration : IEntityTypeConfiguration<PhaseItem>
{
    public void Configure(EntityTypeBuilder<PhaseItem> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.PhaseItemNumber)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.PhaseItemName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.AcumulativePercentage)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.ProgressPercentage)
           .HasColumnType("decimal(18, 2)")
           .IsRequired();

        builder.Property(x => x.ExecutionProgress)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.RFI)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.WIR)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.Schedule)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.Unit)
           .HasColumnType("varchar(max)")
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
