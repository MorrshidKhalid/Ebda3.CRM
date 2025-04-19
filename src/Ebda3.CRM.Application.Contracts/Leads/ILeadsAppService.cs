using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM.Leads;

public interface ILeadsAppService : IApplicationService
{
    Task<LeadDto> CreateAsync(CreateUpdateLeadDto input);
}