namespace WorkingWithHostedService.Services;

public class PeriodicHostedService : BackgroundService
{
    private readonly ILogger<PeriodicHostedService> _logger;
    private readonly SettingService _settingService;

    private readonly TimeSpan _period = TimeSpan.FromSeconds(5);
    private int _executionCount = 0;

    public PeriodicHostedService(ILogger<PeriodicHostedService> logger, SettingService settingService)
    {
        _logger = logger;
        _settingService = settingService;
    }

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
