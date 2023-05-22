using AvaTrade.News.Infrastructure.Data.Extensions;
using AvaTrade.News.NewsFeeder;
using AvaTrade.News.Infrastructure.PolygonNewsFetcher.Extensions;
using AvaTrade.News.Application.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddOptions<FeederConfiguration>();
        services.Configure<FeederConfiguration>(context.Configuration.GetSection(nameof(FeederConfiguration)));
        services.AddHostedService<FeederService>();
        services.AddNewsDbContext(context.Configuration);
        services.AddPolygonNewsFetcher(context.Configuration);
        services.AddNewsServices();
    })
    .Build();

host.Run();
