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
    private const string NumberPlaceHolder = "00000";
    private const string EmailPlaceHolder = "em@email.com";
    
    private readonly IRepository<Lead, Guid> _leadRepository;
    public LeadManager(IRepository<Lead, Guid> leadRepository)
    {
        _leadRepository = leadRepository;
    }
    
    /// <summary>
    /// To Make suer a new lead email, or phone number is not exists in the database.
    /// </summary>
    /// <param name="values">[0] to email, [1] for phone number</param>
    /// <exception cref="EmailTakenException">To inform that the email is already taken</exception>
    /// <exception cref="PhoneNumberTakenException">To inform that the phone number is already taken</exception>
    public async Task PreventDuplicateEmailAndPhone(string[] values)
    {
        bool isEmailTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.Email == values[0]);
        if (isEmailTaken)
        {
            throw new EmailTakenException(values[0]);
        }
        
        bool isPhoneTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.PhoneNumber == values[1]);
        if (isPhoneTaken)
        {
            throw new PhoneNumberTakenException(values[1]);
        }
    }

    public async Task<Lead> CreateAsync(
        string[] values, ContactInfo contactInfo, Address address,
        LeadSource source, LeadStatus status)
    {
        Check.NotNull(values, nameof(values));
        Check.NotNull(contactInfo, nameof(contactInfo));
        Check.NotNull(address, nameof(address));
        Check.NotNull(contactInfo, nameof(contactInfo));
        Check.Positive((int)source, nameof(source));
        Check.Positive((int)status, nameof(status));
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

    public async Task ChangeEmail(Lead lead, string newEmail)
    {
        Check.NotNull(lead, nameof(lead));
        Check.NotNullOrWhiteSpace(newEmail, nameof(newEmail));

        await PreventDuplicateEmailAndPhone([newEmail, NumberPlaceHolder]);
        
        lead.UpdateContacts(new ContactInfo(lead.ContactInfo.PhoneNumber, newEmail));
    }

    public async Task ChangePhone(Lead lead, string newPhone)
    {
        Check.NotNull(lead, nameof(lead));
        Check.NotNullOrWhiteSpace(newPhone, nameof(newPhone));
        
        await PreventDuplicateEmailAndPhone([EmailPlaceHolder, newPhone]);
        
        lead.UpdateContacts(new ContactInfo(lead.ContactInfo.PhoneNumber, newPhone));
    }
}