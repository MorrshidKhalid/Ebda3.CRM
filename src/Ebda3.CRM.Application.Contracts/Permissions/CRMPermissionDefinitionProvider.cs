using Ebda3.CRM.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Ebda3.CRM.Permissions;

public class CRMPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //Obj type => [PermissionGroupDefinition].
        var crmGroup = context.AddGroup(CRMPermissions.GroupName, L("Permission:Crm")); //Used to group permission in th UI. 
        
        //Here I define permission to the group I defined above.
        crmGroup.AddPermission(CRMPermissions.Products.View, L("Permission:Products.View"));
        crmGroup.AddPermission(CRMPermissions.Products.Create, L("Permission:Products.Create"));
        crmGroup.AddPermission(CRMPermissions.Products.Edit, L("Permission:Products.Edit"));
        crmGroup.AddPermission(CRMPermissions.Products.Delete, L("Permission:Products.Delete"));
        
    }

    private static LocalizableString L(string name)     
    {
        return LocalizableString.Create<CRMResource>(name);
    }
}
