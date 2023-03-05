using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeRetro.Shared.Transactions;

public class AutoDbMigration
{
    private readonly IServiceProvider _serviceProvider;

    public AutoDbMigration(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Migrate(CancellationToken cancellationToken)
    {
        var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(a => a.GetTypes())
           .Where(t => typeof(DbContext).IsAssignableFrom(t) && !t.IsInterface && t != typeof(DbContext));

        using var scope = _serviceProvider.CreateScope();
        foreach (var dbContextType in dbContextTypes)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;
            if (dbContext is null) continue;

            await dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
