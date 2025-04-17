using System;
using Volo.Abp.Application.Dtos;

namespace Ebda3.CRM.Leads;

public class LeadDto : FullAuditedEntityDto<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Camponey { get; set; }
    public string Industry { get; set; }
    public LeadSource Source { get; set; }
    public LeadStatus Status { get; set; }
}