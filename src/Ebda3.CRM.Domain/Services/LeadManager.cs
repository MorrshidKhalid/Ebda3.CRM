using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Ebda3.CRM.Specifications;
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
    
    /// <summary>
    /// To Make suer a new lead email, or phone number is not exists in the database.
    /// </summary>
    /// <param name="values">[0] to email, [1] for phone number</param>
    /// <exception cref="UserFriendlyException">To inform that the email or phone number is already taken</exception>
    public async Task PreventDuplicateEmailAndPhone(string[] values)
    {
        bool isEmailTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.Email == values[0]);
        if (isEmailTaken)
        {
            throw new UserFriendlyException("Email is taken");
        }
        
        bool isPhoneTaken = await _leadRepository.AnyAsync(x => x.ContactInfo.PhoneNumber == values[1]);
        if (isPhoneTaken)
        {
            throw new UserFriendlyException("Phone number is taken");
        }
    }
}