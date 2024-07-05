using Bitbone3d.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bitbone3d.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Bitbone3dController : AbpControllerBase
{
    protected Bitbone3dController()
    {
        LocalizationResource = typeof(Bitbone3dResource);
    }
}
