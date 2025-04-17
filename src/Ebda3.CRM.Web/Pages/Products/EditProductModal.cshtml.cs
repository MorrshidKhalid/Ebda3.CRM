using System;
using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ebda3.CRM.Web.Pages.Products;

public class EditProductModalModel : CRMPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    
    [BindProperty]
    public CreateEditProductViewModel Product { get; set; }
    public SelectListItem[] Categories { get; set; }
    
    
    private readonly IProductAppService _productAppService;

    public EditProductModalModel(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    public async Task OnGetAsync()
    {
        var productDto = await _productAppService.GetAsync(Id);
        Product = ObjectMapper
            .Map<ProductDto, CreateEditProductViewModel>(productDto);

        var categoryLookup = await _productAppService.GetCategoriesLookupListAsync();
        Categories = categoryLookup.Items.Select(x => new SelectListItem(
            x.Name, x.Id.ToString()
        )).ToArray();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productAppService.UpdateAsync(
            Id, ObjectMapper
                .Map<CreateEditProductViewModel, CreateUpdateProductDto>(Product)
        );
        
        return NoContent();
    }
}