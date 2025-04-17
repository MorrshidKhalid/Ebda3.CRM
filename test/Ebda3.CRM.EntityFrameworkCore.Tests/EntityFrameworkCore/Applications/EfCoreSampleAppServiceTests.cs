using Ebda3.CRM.Samples;
using Xunit;

namespace Ebda3.CRM.EntityFrameworkCore.Applications;

[Collection(CRMTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CRMEntityFrameworkCoreTestModule>
{

}
