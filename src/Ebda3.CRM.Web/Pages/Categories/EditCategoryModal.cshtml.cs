using System;
using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Categories;
using Ebda3.CRM.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Web.Pages.Categories;

public class EditCategoryModalModel : CRMPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    
    [BindProperty]
    public CreateEditCategoryViewModel Category { get; set; }
    
    private readonly ICategoryAppService _categoryAppService;
    
    private readonly IRepository<Category, Guid> _repo;

    public EditCategoryModalModel(ICategoryAppService categoryAppService, IRepository<Category, Guid> repo)
    {
        _categoryAppService = categoryAppService;
        _repo = repo;
    }

    public async Task OnGetAsync()
    {
        var categoryDto = await _categoryAppService.GetAsync(Id);
        Category = ObjectMapper
            .Map<CategoryDto, CreateEditCategoryViewModel>(categoryDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        
        Category ctg = await _repo.GetAsync(Id);
        ObjectMapper.Map(Category, ctg);
        
        // await _categoryAppService.UpdateAsync(
        //     Id, ObjectMapper
        //         .Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(Category)
        // );
        //
        return NoContent();
    }
}