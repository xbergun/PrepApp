using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Core.Entity.Independent;

namespace NTT.Repository.Context.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");
        builder.HasKey(x => x.Id);
        builder.HasMany(b => b.Posts).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId);
    }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Blog).WithMany(b => b.Posts).HasForeignKey(p => p.BlogId);
    }
}