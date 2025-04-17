using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Ebda3.CRM.Pages;

[Collection(CRMTestConsts.CollectionDefinitionName)]
public class Index_Tests : CRMWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
