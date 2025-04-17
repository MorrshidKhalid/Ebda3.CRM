using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;

namespace Ebda3.CRM.Web.Pages.Products;

public class CreateProductModalModel : CRMPageModel
{
    [BindProperty]
    public CreateEditProductViewModel Product { get; set; }
    public SelectListItem[] Categories { get; set; }

    private readonly IProductAppService _productAppService;
    public CreateProductModalModel(IProductAppService productAppService) 
        => _productAppService = productAppService;

    public async Task OnGetAsync()
    {
        Product = new CreateEditProductViewModel
        {
            ReleaseDate = Clock.Now,
            StockState = ProductStockState.PreOrder
        };

        ListResultDto<CategoryLookupDto> categoryLookup 
            = await _productAppService.GetCategoriesLookupListAsync();

        Categories = categoryLookup
            .Items.Select(x => 
                new SelectListItem(x.Name, x.Id.ToString()))
            .ToArray();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productAppService.CreateAsync(
            ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(Product)
        );

        return NoContent();
    }
}