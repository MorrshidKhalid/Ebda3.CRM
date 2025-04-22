using System;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Application.Dtos;

namespace Ebda3.CRM.Leads;

public class LeadDto : FullAuditedEntityDto<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public string Company { get; set; }
    public string Industry { get; set; }
    public LeadSource Source { get; set; }
    public LeadStatus Status { get; set; }


    
}