using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class BoardMemberConfiguration : IEntityTypeConfiguration<BoardMember>
{
    public void Configure(EntityTypeBuilder<BoardMember> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.NameEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.PositionAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.PositionEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.HasMany(x => x.BoardMemberSpeeches)
           .WithOne(x => x.BoardMember)
           .HasForeignKey(x => x.BoardMemberId)
           .IsRequired();

        builder.ToTable("BoardMembers");
    }
}
