using Volo.Abp.Modularity;

namespace Ebda3.CRM;

[DependsOn(
    typeof(CRMApplicationModule),
    typeof(CRMDomainTestModule)
)]
public class CRMApplicationTestModule : AbpModule
{

}
