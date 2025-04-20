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

    public async Task IsEmailTaken(string email)
    {
        bool isTaken = await _leadRepository.AnyAsync(x => x.Email == email);
        if (isTaken)
        {
            throw new UserFriendlyException("Email is taken");
        }
    }
    public async Task<List<Lead>> FindRejectedLeads()
    {
        IQueryable<Lead> queryable  = await _leadRepository.GetQueryableAsync();
        queryable = queryable .Where(
            new RejectedLeadSpecification().ToExpression()
            );

        return await AsyncExecuter.ToListAsync(queryable);
    }
}