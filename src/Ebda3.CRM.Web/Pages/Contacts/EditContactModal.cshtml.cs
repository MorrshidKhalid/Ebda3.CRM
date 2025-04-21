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
        ContactViewModel = ObjectMapper.Map<LeadDto, CreateEditContactsViewModel>(
            await _leadAppService.FindLeadDtoAsync(Id));
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

/*
 * new CreateEditContactsViewModel()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@mail.com",
            Phone = "021555145",
            Street = "123 Main Street",
            City = "London",
            State = "London",
            ZipCode = "00000",
            Camponey = "John Doe",
            Industry = "Software Engineering",
            Source = LeadSource.Ads,
            Status = LeadStatus.Approved
        };
*/