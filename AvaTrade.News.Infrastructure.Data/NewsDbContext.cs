using AvaTrade.News.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AvaTrade.News.Infrastructure.Data;

public class NewsDbContext: DbContext
{
    public NewsDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
