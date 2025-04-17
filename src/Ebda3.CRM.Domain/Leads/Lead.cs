using System;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Leads;

public class Lead : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Address Address { get; }
    public string Camponey { get; set; }
    public string Industry { get; set; }
    public LeadSource Source { get; set; }
    public LeadStatus Status { get; set; }
}