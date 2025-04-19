using System;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Leads;

public class Lead : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
    public Address Address { get; }
    public string Camponey { get; }
    public string Industry { get; }
    public LeadSource Source { get; }
    public LeadStatus Status { get; }
    public string? AssignedTo { get; }

    public Lead()
    {
        //Required for EF Core.
    }

    public Lead(Guid id,  string firstName, string lastName,
        string email, string phone, Address address,
        string camponey, string industry, LeadSource source,
        LeadStatus status, string? assignedTo = null) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
        Camponey = camponey;
        Industry = industry;
        Source = source;
        Status = status;
        AssignedTo = assignedTo;
    }
}