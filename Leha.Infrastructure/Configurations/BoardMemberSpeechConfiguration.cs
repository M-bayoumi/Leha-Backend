using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class BoardMemberSpeechConfiguration : IEntityTypeConfiguration<BoardMemberSpeech>
{
    public void Configure(EntityTypeBuilder<BoardMemberSpeech> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.BoardMemberSpeechContent)
           .HasColumnType("varchar(max)")
           .IsRequired();


        builder.ToTable("BoardMemberSpeeches");
    }
}
