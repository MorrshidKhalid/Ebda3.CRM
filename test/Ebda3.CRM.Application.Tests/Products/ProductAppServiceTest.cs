using System;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace Ebda3.CRM.Products;

public abstract class ProductAppServiceTest<TStartupModule> : CRMApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IProductAppService _productAppService;

    protected ProductAppServiceTest()
    {
        _productAppService = GetRequiredService<IProductAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Products_Dtos()
    {
        //Act
        var result = await _productAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
            );
        
        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
    }
}