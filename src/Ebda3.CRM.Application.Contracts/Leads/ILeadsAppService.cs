using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ebda3.CRM.Leads;

public interface ILeadsAppService : 
    ICrudAppService<
    LeadDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateLeadDto>
{
}