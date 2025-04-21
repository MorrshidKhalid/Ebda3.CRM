using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ebda3.CRM.Leads;
using Ebda3.CRM.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ebda3.CRM.EntityFrameworkCore.Leads;

public class LeadRepository : EfCoreRepository<CRMDbContext, Lead, Guid>, ILeadRepository
{
    public LeadRepository(IDbContextProvider<CRMDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }

    public async Task DeleteLeadByStatusAsync(LeadStatus status)
    {
        var dbContext = await GetDbContextAsync();
        await dbContext.Database.ExecuteSqlAsync($"DELETE FROM Lead WHERE Status = {(int)status}");
    }
    
    public async Task DeleteLeadBySourceAsync(LeadSource source)
    {
        var dbContext = await GetDbContextAsync();
        await dbContext.Database.ExecuteSqlAsync($"DELETE FROM Lead WHERE Source = {(int)source}");
    }
    public async Task<List<Lead>> GetAllBySourceAsync(LeadSource source)
    {
        var dbContext = await GetDbContextAsync();
        
        return dbContext.Leads.Where(x => x.Source == source).ToList();
    }

    public async Task<List<Lead>> GetAllByStatusAsync(LeadStatus status)
    {
        var dbContext = await GetDbContextAsync();
        
        return dbContext.Leads.Where(x => x.Status == status).ToList();
    }
}