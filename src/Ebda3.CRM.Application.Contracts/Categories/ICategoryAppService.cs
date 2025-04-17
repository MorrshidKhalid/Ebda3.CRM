using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM.Categories;

    public interface ICategoryAppService :
        ICrudAppService<
        CategoryDto, //To show
        Guid, //PK
        PagedAndSortedResultRequestDto, //Paging and sort
        CreateUpdateCategoryDto> //TO create and update
    {
}