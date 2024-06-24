using UowTest814.Samples;
using Xunit;

namespace UowTest814.EntityFrameworkCore.Applications;

[Collection(UowTest814TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<UowTest814EntityFrameworkCoreTestModule>
{

}
