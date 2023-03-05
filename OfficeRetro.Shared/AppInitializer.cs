using Microsoft.Extensions.Hosting;
using OfficeRetro.Shared.Transactions;

namespace OfficeRetro.Shared.Services;

internal sealed class AppInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public AppInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var autoMigration = new AutoDbMigration(_serviceProvider);
        await autoMigration.Migrate(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
