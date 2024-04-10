using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class BoardMemberSpeechConfiguration : IEntityTypeConfiguration<BoardMemberSpeech>
{
    public void Configure(EntityTypeBuilder<BoardMemberSpeech> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ContentAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ContentEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DateTime)
           .HasColumnType("datetime")
           .IsRequired();

        builder.ToTable("BoardMemberSpeeches");
    }
}
