using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PlumGuide.Exercises.PlutoRover.DataAccess;

public class DataMigrationBackgroundWorker : BackgroundService
{
    private readonly IServiceProvider _provider;

    public DataMigrationBackgroundWorker(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _provider.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<PlutoRoverDbContext>();

        await ctx.Database.MigrateAsync();
    }
}
