using Ebda3.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ebda3.CRM.Web.Pages;

public abstract class CRMPageModel : AbpPageModel
{
    protected CRMPageModel()
    {
        LocalizationResourceType = typeof(CRMResource);
    }
}
