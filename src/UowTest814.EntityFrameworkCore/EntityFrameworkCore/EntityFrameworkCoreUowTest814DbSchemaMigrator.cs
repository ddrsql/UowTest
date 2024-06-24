using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UowTest814.Data;
using Volo.Abp.DependencyInjection;

namespace UowTest814.EntityFrameworkCore;

public class EntityFrameworkCoreUowTest814DbSchemaMigrator
    : IUowTest814DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreUowTest814DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the UowTest814DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<UowTest814DbContext>()
            .Database
            .MigrateAsync();
    }
}
