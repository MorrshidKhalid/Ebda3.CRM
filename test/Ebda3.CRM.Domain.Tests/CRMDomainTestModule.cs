using Volo.Abp.Modularity;

namespace Ebda3.CRM;

[DependsOn(
    typeof(CRMDomainModule),
    typeof(CRMTestBaseModule)
)]
public class CRMDomainTestModule : AbpModule
{

}
