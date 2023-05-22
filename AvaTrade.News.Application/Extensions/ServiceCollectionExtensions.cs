using AvaTrade.News.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AvaTrade.News.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddNewsServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddScoped<IInstrumentMapper, InstrumentMapper>();
    }
}
