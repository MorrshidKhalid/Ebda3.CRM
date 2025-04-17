using Volo.Abp.Modularity;

namespace Ebda3.CRM;

public abstract class CRMApplicationTestBase<TStartupModule> : CRMTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
