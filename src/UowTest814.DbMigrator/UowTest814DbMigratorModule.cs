using UowTest814.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace UowTest814.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UowTest814EntityFrameworkCoreModule),
    typeof(UowTest814ApplicationContractsModule)
    )]
public class UowTest814DbMigratorModule : AbpModule
{
}
