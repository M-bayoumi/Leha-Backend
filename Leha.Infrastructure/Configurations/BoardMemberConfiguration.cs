using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class BoardMemberConfiguration : IEntityTypeConfiguration<BoardMember>
{
    public void Configure(EntityTypeBuilder<BoardMember> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.BoardMemberName)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.BoardMemberImage)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.BoardMemberPosition)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.HasMany(x => x.BoardMemberSpeeches)
           .WithOne(x => x.BoardMember)
           .HasForeignKey(x => x.BoardMemberID)
           .IsRequired();

        builder.ToTable("BoardMembers");
    }
}
