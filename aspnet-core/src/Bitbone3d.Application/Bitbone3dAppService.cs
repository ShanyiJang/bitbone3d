using System;
using System.Collections.Generic;
using System.Text;
using Bitbone3d.Localization;
using Volo.Abp.Application.Services;

namespace Bitbone3d;

/* Inherit your application services from this class.
 */
public abstract class Bitbone3dAppService : ApplicationService
{
    protected Bitbone3dAppService()
    {
        LocalizationResource = typeof(Bitbone3dResource);
    }
}
