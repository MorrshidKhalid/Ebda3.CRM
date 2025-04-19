using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM.Leads;

public interface ILeadAppService : IApplicationService
{
    Task<LeadDto> CreateAsync(CreateUpdateLeadDto input);
    Task<List<LeadDto>> GetAllLeadsAsync();
}