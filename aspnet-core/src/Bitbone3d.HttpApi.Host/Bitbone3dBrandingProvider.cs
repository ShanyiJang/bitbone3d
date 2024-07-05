using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bitbone3d;

[Dependency(ReplaceServices = true)]
public class Bitbone3dBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bitbone3d";
}
