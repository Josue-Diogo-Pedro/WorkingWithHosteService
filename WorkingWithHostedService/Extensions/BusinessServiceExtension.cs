using WorkingWithHostedService.Services;

namespace WorkingWithHostedService.Extensions;

public static class BusinessServiceExtension
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<SampleService>();
        services.AddSingleton<SettingService>();
        services.AddSingleton<PeriodicHostedService>();
        services.AddHostedService(provider =>
            provider.GetRequiredService<PeriodicHostedService>()
        );
    }
}
