using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Repositories;

public interface ILeadRepository : IRepository<Lead, Guid>
{
    
    Task DeleteLeadByStatusAsync(LeadStatus status);
    Task DeleteLeadBySourceAsync(LeadSource source);
    Task<Lead?> FindByIdAsync(Guid id);
    Task<List<Lead>> FindAllAsync();
    Task<List<Lead>> GetAllBySourceAsync(LeadSource source);
    Task<List<Lead>> GetAllByStatusAsync(LeadStatus status);
}