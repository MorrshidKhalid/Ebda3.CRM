using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Categories;

public class CategoryAppService :
    CrudAppService<
    Category,
    CategoryDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCategoryDto>,
    ICategoryAppService
{
    public CategoryAppService(IRepository<Category, Guid> repository) 
        : base(repository)
    {
    }
}