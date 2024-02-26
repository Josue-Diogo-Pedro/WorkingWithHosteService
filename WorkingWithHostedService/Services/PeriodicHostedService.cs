namespace WorkingWithHostedService.Services;

public class PeriodicHostedService : BackgroundService
{
    private readonly ILogger<PeriodicHostedService> _logger;

    public PeriodicHostedService(ILogger<PeriodicHostedService> logger)
    {
        _logger = logger;
    }

    private readonly TimeSpan _period = TimeSpan.FromSeconds(5);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_period);

        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to execute periodicService {ex.Message}");
            }
        }
    }
}
