using Volo.Abp.Modularity;

namespace UowTest814;

[DependsOn(
    typeof(UowTest814DomainModule),
    typeof(UowTest814TestBaseModule)
)]
public class UowTest814DomainTestModule : AbpModule
{

}
