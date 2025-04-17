using Volo.Abp.Modularity;

namespace Ebda3.CRM;

/* Inherit from this class for your domain layer tests. */
public abstract class CRMDomainTestBase<TStartupModule> : CRMTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
