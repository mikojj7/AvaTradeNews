using AvaTrade.News.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaTrade.News.Infrastructure.PolygonNewsFetcher.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPolygonNewsFetcher(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<INewsFetcher, PolygonNewsFetcher>(options =>
        {
            var polygonUrl = configuration["PolygonConfiguration:Url"];
            var apiKey = configuration["PolygonConfiguration:ApiKey"];
            
            options.BaseAddress = new Uri($"{polygonUrl}?limit=100&order=descending&sort=published_utc&apiKey={apiKey}");
        });
    }
}
