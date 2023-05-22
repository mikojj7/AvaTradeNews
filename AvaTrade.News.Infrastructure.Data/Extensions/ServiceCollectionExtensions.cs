using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaTrade.News.Infrastructure.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddNewsDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NewsDbContext>(
            options => options.UseSqlServer(configuration["ConnectionString"]));

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
    }
}
