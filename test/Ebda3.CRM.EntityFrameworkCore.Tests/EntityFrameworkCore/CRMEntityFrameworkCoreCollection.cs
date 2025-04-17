using Xunit;

namespace Ebda3.CRM.EntityFrameworkCore;

[CollectionDefinition(CRMTestConsts.CollectionDefinitionName)]
public class CRMEntityFrameworkCoreCollection : ICollectionFixture<CRMEntityFrameworkCoreFixture>
{

}
