using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ContentAr)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.ContentEn)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.Image)
           .HasColumnType("Nvarchar(max)")
           .IsRequired();

        builder.Property(x => x.DateTime)
           .HasColumnType("datetime")
           .IsRequired();

        builder.ToTable("Posts");
    }
}
