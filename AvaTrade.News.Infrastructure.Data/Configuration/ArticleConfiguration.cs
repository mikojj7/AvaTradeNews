using AvaTrade.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaTrade.News.Infrastructure.Data.Configuration;

internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.RefId).IsUnique();
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.ArticleUrl).IsRequired();
    }
}
