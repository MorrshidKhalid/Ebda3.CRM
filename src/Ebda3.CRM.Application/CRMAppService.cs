using Ebda3.CRM.Localization;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM;

/* Inherit your application services from this class.
 */
public abstract class CRMAppService : ApplicationService
{
    protected CRMAppService()
    {
        LocalizationResource = typeof(CRMResource);
    }
}
