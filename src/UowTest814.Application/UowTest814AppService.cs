using System;
using System.Collections.Generic;
using System.Text;
using UowTest814.Localization;
using Volo.Abp.Application.Services;

namespace UowTest814;

/* Inherit your application services from this class.
 */
public abstract class UowTest814AppService : ApplicationService
{
    protected UowTest814AppService()
    {
        LocalizationResource = typeof(UowTest814Resource);
    }
}
