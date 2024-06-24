using Volo.Abp.Modularity;

namespace UowTest814;

/* Inherit from this class for your domain layer tests. */
public abstract class UowTest814DomainTestBase<TStartupModule> : UowTest814TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
