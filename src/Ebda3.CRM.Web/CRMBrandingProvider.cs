using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Ebda3.CRM.Localization;

namespace Ebda3.CRM.Web;

[Dependency(ReplaceServices = true)]
public class CRMBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<CRMResource> _localizer;

    public CRMBrandingProvider(IStringLocalizer<CRMResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
