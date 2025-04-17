using Ebda3.CRM.Samples;
using Xunit;

namespace Ebda3.CRM.EntityFrameworkCore.Domains;

[Collection(CRMTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CRMEntityFrameworkCoreTestModule>
{

}
