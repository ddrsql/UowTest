using UowTest814.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace UowTest814.Permissions;

public class UowTest814PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UowTest814Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UowTest814Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UowTest814Resource>(name);
    }
}
