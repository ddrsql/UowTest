using UowTest814.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace UowTest814.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UowTest814Controller : AbpControllerBase
{
    protected UowTest814Controller()
    {
        LocalizationResource = typeof(UowTest814Resource);
    }
}
