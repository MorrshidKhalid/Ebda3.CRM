using System;
using System.Runtime.CompilerServices;
using Ebda3.CRM.ValueObjects;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Leads;


public class Lead : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public Address Address { get; private set; }
    public string Company { get; private set; }
    public string Industry { get; private set; }
    public LeadSource Source { get; private set; }
    public LeadStatus Status { get; private set; } = LeadStatus.New;
    public string? AssignedTo { get; private set; }

    protected Lead()
    {
        //Required for EF Core.
    }

    public Lead(Guid id,  string firstName, string lastName,
        ContactInfo contactInfo, Address address,
        string company, string industry, LeadSource source,
        LeadStatus status, string? assignedTo = null) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ContactInfo = contactInfo;
        Address = address;
        Company = company;
        Industry = industry;
        Source = source;
        Status = status;
        AssignedTo = assignedTo;
    }

    
    public void ChangeAddress(Address newAddress)
    {
        //Replace with (newAddress) to keep it immutable.
        Address = newAddress;
    }
    
    public void Rename(string inputFirstName, string inputLastName)
    {
        Check.Length(inputFirstName, nameof(inputFirstName), LeadConsts.MaxNameLength);
        Check.Length(inputLastName, nameof(inputLastName), LeadConsts.MaxNameLength);
        Check.NotNullOrWhiteSpace(inputFirstName, nameof(inputFirstName));
        Check.NotNullOrWhiteSpace(inputLastName, nameof(inputLastName));
        
        FirstName = inputFirstName;
        LastName = inputLastName;
    }

    public void UpdateContacts(ContactInfo info)
    {
        //Replace with (info) to keep it immutable.
        ContactInfo = info;
    }

    public void UpdateCompanyAndIndustry(string inputCompany, string inputIndustry)
    {
        Company = inputCompany;
        Industry = inputIndustry;
    }

    public void ChangeStatus(LeadStatus inputStatus)
    {
        Status = inputStatus;
    }

    public void ChangeSource(LeadSource inputSource)
    {
        Source = inputSource;
    }
}

