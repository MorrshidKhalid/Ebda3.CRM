using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ebda3.CRM.Repositories;
using Ebda3.CRM.Services;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Leads;

public class LeadAppService : CRMAppService, ILeadAppService
{
    private readonly IRepository<Lead, Guid> _repository;
    private readonly LeadManager _leadManager;

    public LeadAppService(IRepository<Lead, Guid> repository, LeadManager manager)
    {
        _repository = repository;
        _leadManager = manager;
    }

    public async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
    {
        
        string[] values = [input.FirstName, input.LastName, input.Company, input.Industry];
        Address address = new Address(input.Street, input.City, input.State, input.ZipCode);
        ContactInfo contactInfo = new ContactInfo(input.Phone, input.Email);
        
        Lead createdLead = await _leadManager.CreateAsync(
            values, contactInfo, address, input.Source, input.Status);
        
        return ObjectMapper.Map<Lead, LeadDto>(await _repository.InsertAsync(createdLead));;
    }
    
    //GetAllLeads Used in js file via (Dynamic JS Proxies)
    public async Task<PagedResultDto<LeadDto>> GetAllLeadsAsync()
    {
        var leads = await _repository.GetListAsync();

        var leadDtos = ObjectMapper.Map<List<Lead>, List<LeadDto>>(leads);
        
        return new PagedResultDto<LeadDto>(leads.Count, leadDtos);
    }
    
    public async Task<LeadDto> FindLeadDtoAsync(Guid leadId)
    {
        Lead lead = await _repository.GetAsync(leadId);
        
        return ObjectMapper.Map<Lead, LeadDto>(lead);
    }
    
    public async Task UpdateLeadAsync(Guid id, CreateUpdateLeadDto input)
    {
        var lead = await _repository.GetAsync(id);
        await UpdateLeadMembersAsync(lead, input);
        
        ObjectMapper.Map(input, lead);
    }

    //DeleteLead Used in js file via (Dynamic JS Proxies)
    public async Task DeleteLeadAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    private async Task UpdateLeadMembersAsync(Lead lead, CreateUpdateLeadDto input)
    {
        lead.Rename(input.FirstName, input.LastName);
        await _leadManager.ChangeContactInfoAsync(lead, new ContactInfo(input.Phone, input.Email));
        lead.ChangeAddress(new Address(input.Street, input.City, input.State, input.ZipCode));
        lead.UpdateCompanyAndIndustry(input.Company, input.Industry);
        lead.ChangeStatus(input.Status);
        lead.ChangeSource(input.Source);
    }
}