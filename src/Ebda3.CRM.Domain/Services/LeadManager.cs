using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Exceptions;
using Ebda3.CRM.Leads;
using Ebda3.CRM.Specifications;
using Ebda3.CRM.ValueObjects;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ebda3.CRM.Services;

public class LeadManager : DomainService
{
    private readonly IRepository<Lead, Guid> _leadRepository;
    public LeadManager(IRepository<Lead, Guid> leadRepository)
    {
        _leadRepository = leadRepository;
    }
    
    public async Task PreventDuplicateEmail(string email)
    {
        bool isEmailTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.Email == email);
        if (isEmailTaken)
        {
            throw new EmailTakenException(email);
        }
    }

    public async Task PreventDuplicatePhone(string phone)
    {
        bool isPhoneTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.PhoneNumber == phone);
        if (isPhoneTaken)
        {
            throw new PhoneNumberTakenException(phone);
        }
        
    }
    
    /// <summary>
    /// To Make suer a new lead email, and phone number is not exists in the database.
    /// </summary>
    /// <param name="values">[0] to email, [1] for phone number</param>
    public async Task PreventDuplicateEmailAndPhone(string[] values)
    {
        await PreventDuplicateEmail(values[0]);
        await PreventDuplicatePhone(values[1]);
    }
    
    public async Task<Lead> CreateAsync(
        string[] values, ContactInfo contactInfo, Address address,
        LeadSource source, LeadStatus status)
    {
        Check.NotNull(values, nameof(values));
        Check.NotNull(contactInfo, nameof(contactInfo));
        Check.NotNull(address, nameof(address));
        Check.NotNull(contactInfo, nameof(contactInfo));
        Check.Range((int)source, nameof(source), LeadConsts.MinEnumValue, LeadConsts.MaxEnumValue);
        Check.Range((int)status, nameof(status), LeadConsts.MinEnumValue, LeadConsts.MaxEnumValue);
        await PreventDuplicateEmailAndPhone([contactInfo.Email, contactInfo.PhoneNumber]);

        return new Lead(
            GuidGenerator.Create(),
            values[0], //FirstName
            values[1], //LastName
            contactInfo,
            address,
            values[2], //Company
            values[3], //Industry
            source,
            status
            );
    }

    public async Task ChangeEmailAsync(Lead lead, string newEmail)
    {
        Check.NotNull(lead, nameof(lead));
        Check.NotNullOrWhiteSpace(newEmail, nameof(newEmail));

        if (!lead.ContactInfo.Email.Equals(newEmail))
        {
            await PreventDuplicateEmail(newEmail);
        }

        lead.ChangeEmail(newEmail);
    }
    public async Task ChangePhoneAsync(Lead lead, string newPhone)
    {
        Check.NotNull(lead, nameof(lead));
        Check.NotNullOrWhiteSpace(newPhone, nameof(newPhone));

        if (!lead.ContactInfo.PhoneNumber.Equals(newPhone))
        {
            await PreventDuplicatePhone(newPhone);   
        }
        lead.ChangePhoneNumber(newPhone);
    }
    public async Task ChangeContactInfoAsync(Lead lead, ContactInfo contactInfo)
    {
        await ChangeEmailAsync(lead, contactInfo.Email);
        await ChangePhoneAsync(lead, contactInfo.PhoneNumber);
    }
}