using Volo.Abp.Modularity;

namespace UowTest814;

[DependsOn(
    typeof(UowTest814ApplicationModule),
    typeof(UowTest814DomainTestModule)
)]
public class UowTest814ApplicationTestModule : AbpModule
{

}
