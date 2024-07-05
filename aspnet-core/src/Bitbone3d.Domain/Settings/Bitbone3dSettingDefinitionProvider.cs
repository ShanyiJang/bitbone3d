using Volo.Abp.Settings;

namespace Bitbone3d.Settings;

public class Bitbone3dSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(Bitbone3dSettings.MySetting1));
    }
}
