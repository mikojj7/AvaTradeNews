using AvaTrade.News.Application.Modules.News.Commands;
using MediatR;
using Microsoft.Extensions.Options;

namespace AvaTrade.News.NewsFeeder;

internal class FeederService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<FeederService> _logger;
    private readonly FeederConfiguration _configuration;

    public FeederService(IServiceProvider serviceProvider, IOptions<FeederConfiguration> configurationOptions, ILogger<FeederService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _configuration = configurationOptions.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(_configuration.Interval));

        await ImportNews();

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("News Feeder running at: {time}", DateTimeOffset.Now);

            try
            {
                await ImportNews();
            }
            catch (Exception ex)
            {
                //todo - log specific exception
                _logger.LogError(ex, "An error occured while fetching the news");
            }            
        }
    }

    private async Task ImportNews()
    {
        using var scope = _serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        await mediator.Send(new ImportNewsCommand());
    }
}