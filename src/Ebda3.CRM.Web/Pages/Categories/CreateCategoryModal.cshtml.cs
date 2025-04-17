using System.Threading.Tasks;
using Ebda3.CRM.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Ebda3.CRM.Web.Pages.Categories;

public class CreateCategoryModalModel : CRMPageModel
{
    [BindProperty]
    public CreateEditCategoryViewModel Category { get; set; }

    private readonly ICategoryAppService _categoryAppService;

    public CreateCategoryModalModel(ICategoryAppService categoryAppService) 
        => _categoryAppService = categoryAppService;

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _categoryAppService.CreateAsync(
            ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(Category)
            );
        return NoContent();
    }
}