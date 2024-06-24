using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UowTest814.Data;

/* This is used if database provider does't define
 * IUowTest814DbSchemaMigrator implementation.
 */
public class NullUowTest814DbSchemaMigrator : IUowTest814DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
