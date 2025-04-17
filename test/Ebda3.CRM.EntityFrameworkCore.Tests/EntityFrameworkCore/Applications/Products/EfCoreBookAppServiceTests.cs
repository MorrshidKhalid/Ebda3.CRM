using Ebda3.CRM.Products;
using Xunit;

namespace Ebda3.CRM.EntityFrameworkCore.Applications.Products;

[Collection(CRMTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppServiceTests : ProductAppServiceTest<CRMEntityFrameworkCoreTestModule>
{
    
}