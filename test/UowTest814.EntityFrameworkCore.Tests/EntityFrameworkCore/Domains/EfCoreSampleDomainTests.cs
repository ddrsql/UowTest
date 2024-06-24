using UowTest814.Samples;
using Xunit;

namespace UowTest814.EntityFrameworkCore.Domains;

[Collection(UowTest814TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<UowTest814EntityFrameworkCoreTestModule>
{

}
