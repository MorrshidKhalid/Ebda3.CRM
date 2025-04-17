using Ebda3.CRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ebda3.CRM.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CRMEntityFrameworkCoreModule),
    typeof(CRMApplicationContractsModule)
)]
public class CRMDbMigratorModule : AbpModule
{
}
