using Ebda3.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Ebda3.CRM.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CRMController : AbpControllerBase
{
    protected CRMController()
    {
        LocalizationResource = typeof(CRMResource);
    }
}
