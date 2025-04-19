using System.Threading.Tasks;
using Ebda3.CRM.Localization;
using Ebda3.CRM.Permissions;
using Ebda3.CRM.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace Ebda3.CRM.Web.Menus;

public class CRMMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CRMResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                CRMMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);

        

        context.Menu.AddItem(
            new ApplicationMenuItem(
                CRMMenus.CRM,
                l["Menu:CRM"],
                "~/"
                ).
                AddItem(
                    new ApplicationMenuItem(
                        CRMMenus.Contacts,
                        l["Menu:Contacts"],
                        url: "/Leads"
                    )
                )
                .AddItem(
                    new ApplicationMenuItem(
                        CRMMenus.Task,
                        l["Menu:Task"],
                        url: "~/"
                    ))
                .AddItem(
                    new ApplicationMenuItem(
                        CRMMenus.Order,
                        l["Menu:Order"],
                        url: "~/"
                    ))
                .AddItem(
                    new ApplicationMenuItem(
                        CRMMenus.Interactions,
                        l["Menu:Interactions"],
                        url: "~/"
                    ))
            );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                CRMMenus.ManageProducts,
                l["Menu:ManageProducts"],
                "~/"
            ).AddItem(
                new ApplicationMenuItem(
                    CRMMenus.Product,
                    l["Menu:Products"],
                    url: "/Products"
                ))
            .AddItem(
                new ApplicationMenuItem(
                    CRMMenus.Categories,
                    l["Menu:Categories"],
                    url: "/Categories"
                ))
        );
        return Task.CompletedTask;
    }
}
