using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Microsoft.AspNetCore.Mvc;

namespace Ebda3.CRM.Web.Pages.Contacts;

public class CreateLeadModal : CRMPageModel
{
    [BindProperty]
    public CreateEditContactsViewModel Contacts { get; set; }
    
    
    private readonly ILeadAppService _leadAppService;

    public CreateLeadModal(ILeadAppService leadAppService)
    {
        _leadAppService = leadAppService;
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
       var result =  await _leadAppService.CreateAsync(
            ObjectMapper.Map<CreateEditContactsViewModel, CreateUpdateLeadDto>(Contacts)
            );
        
        return NoContent();
    }
}