using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Ebda3.CRM.Categories;
using Ebda3.CRM.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Products;

public class ProductAppService :
    CrudAppService<
        Product,//Entity
        ProductDto,//Toshow
        Guid,//PK
        PagedAndSortedResultRequestDto,//Paging and sort
        CreateUpdateProductDto>, //To create and delete
     IProductAppService //Custom methods
{
    private readonly IRepository<Category, Guid> _categoryRepository;
    private readonly IRepository<Product, Guid> _productRepository;
    public ProductAppService(
        IRepository<Product, Guid> productRepository, 
        IRepository<Category, Guid> categoryRepository) : base(productRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        
        GetListPolicyName = CRMPermissions.Products.View;
        CreatePolicyName = CRMPermissions.Products.Create;
        UpdatePolicyName = CRMPermissions.Products.Edit;
        DeletePolicyName = CRMPermissions.Products.Delete;
    }

    public async Task<PagedResultDto<ProductDto>> GetListWithCategoryAsync(PagedAndSortedResultRequestDto input)
    {
        // WithDetailsAsync is similar to incloud.
        IQueryable<Product> queryable = await _productRepository.WithDetailsAsync(x => x.Category);

        queryable = queryable
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting ?? nameof(Product.Name));


        List<Product> products = await AsyncExecuter.ToListAsync(queryable); // to perform query asynchronously.
        long count = await _productRepository.GetCountAsync(); // Map List of Entity => (Product)To (ProductDto).

        return new PagedResultDto<ProductDto>(
            count, ObjectMapper.Map<List<Product>, List<ProductDto>>(products));throw new NotImplementedException();
    }

    public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesLookupListAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        
        return new ListResultDto<CategoryLookupDto>(
            ObjectMapper.Map
                <List<Category>, List<CategoryLookupDto>>(categories));
    }
    
}