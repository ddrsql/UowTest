using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace UowTest814;

[Dependency(ReplaceServices = true)]
public class UowTest814BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UowTest814";
}
