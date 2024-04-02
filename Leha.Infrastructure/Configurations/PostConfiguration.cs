using Leha.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leha.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.PostContent)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.ServcieImage)
           .HasColumnType("varchar(max)")
           .IsRequired();

        builder.Property(x => x.PostDateTime)
           .HasColumnType("datetime")
           .IsRequired();


        builder.ToTable("Posts");
    }
}
