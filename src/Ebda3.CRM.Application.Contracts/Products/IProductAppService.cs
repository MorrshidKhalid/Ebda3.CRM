using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM.Products;

//Inherit [IApplicationService] to make the autoconfiguration of abp framework,
//like register in DI, turns into REST...etc.
public interface IProductAppService :
    ICrudAppService< //Defines the CRUD methods 
    ProductDto, //To show
    Guid, //PK
    PagedAndSortedResultRequestDto, //Paging and sort
    CreateUpdateProductDto?> //TO create and update
{
    
    Task<PagedResultDto<ProductDto>> GetListWithCategoryAsync(PagedAndSortedResultRequestDto input);
    
    // To use it in add or update for the Front-End (dropdown options)
   Task<ListResultDto<CategoryLookupDto>> GetCategoriesLookupListAsync(); 
}