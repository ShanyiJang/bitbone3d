using Bitbone3d.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bitbone3d.Permissions;

public class Bitbone3dPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Bitbone3dPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(Bitbone3dPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Bitbone3dResource>(name);
    }
}
