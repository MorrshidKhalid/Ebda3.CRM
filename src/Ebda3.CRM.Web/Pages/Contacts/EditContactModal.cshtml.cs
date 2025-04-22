using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Ebda3.CRM.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Web.Pages.Contacts;

public class EditContactModal : CRMPageModel
{
    [BindProperty(SupportsGet = true)]
    [HiddenInput]
    public Guid Id { get; set; }
    
    [BindProperty]
    public CreateEditContactsViewModel ContactViewModel { get; set; }
    
    
    private readonly ILeadAppService _leadAppService;
    
    public EditContactModal(ILeadAppService leadAppService)
    {
        _leadAppService = leadAppService;
    }

    public async Task OnGetAsync()
    {
        var leadDto = await _leadAppService.FindLeadDtoAsync(Id); 
        ContactViewModel = ObjectMapper.Map<LeadDto, CreateEditContactsViewModel>(leadDto);
        ContactViewModel.Email = leadDto.ContactInfo.Email;
        ContactViewModel.Phone = leadDto.ContactInfo.PhoneNumber;
        ContactViewModel.Street = leadDto.Address.Street;
        ContactViewModel.City = leadDto.Address.City;
        ContactViewModel.State = leadDto.Address.State;
        ContactViewModel.ZipCode = leadDto.Address.ZipCode;   
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ContactViewModel == null)
        {
            throw new UserFriendlyException("Contact Object is null");    
        }

        await _leadAppService.UpdateLeadAsync(Id, 
            ObjectMapper.Map<CreateEditContactsViewModel, CreateUpdateLeadDto>(ContactViewModel));
        
        return NoContent();
    }
}
