using System;
using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ebda3.CRM.Services;

public class LeadDomainServiceImpl : DomainService
{
    private readonly IRepository<Lead, Guid> _leadRepository;

    public LeadDomainServiceImpl(IRepository<Lead, Guid> leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task IsEmailTaken(string email)
    {
        bool isTaken = await _leadRepository.AnyAsync(x => x.Email == email);
        if (isTaken)
        {
            throw new UserFriendlyException("Email is taken");
        }
    }
}