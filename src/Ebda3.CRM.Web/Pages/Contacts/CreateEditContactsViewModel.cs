using System.ComponentModel.DataAnnotations;
using Ebda3.CRM.Leads;

namespace Ebda3.CRM.Web.Pages.Contacts;

public class CreateEditContactsViewModel
{
    [Required]
    [MaxLength(LeadConsts.MaxNameLength)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxNameLength)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxEmailLength)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxPhoneLength)]
    public string Phone { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxStreetLength)]
    public string Street { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxCityLength)]
    public string City { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxStateLength)]
    public string State { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxZipCodeLength)]
    public string ZipCode { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxCompanyLength)]
    public string Company { get; set; }
    
    [Required]
    [MaxLength(LeadConsts.MaxIndustryLength)]
    public string Industry { get; set; }
    
    [Required]
    public LeadSource Source { get; set; }
    
    [Required]
    public LeadStatus Status { get; set; }
}