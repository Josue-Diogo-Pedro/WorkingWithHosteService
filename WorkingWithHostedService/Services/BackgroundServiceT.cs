using System.Threading;

namespace WorkingWithHostedService.Services;

public class BackgroundServiceT : BackgroundService
{
    readonly ILogger<BackgroundServiceT> _logger;

    public BackgroundServiceT(ILogger<BackgroundServiceT> logger)
    {
        _logger = logger;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
