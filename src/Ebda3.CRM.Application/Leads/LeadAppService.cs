using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ebda3.CRM.Services;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Ebda3.CRM.Leads;

public class LeadAppService : CRMAppService, ILeadAppService
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<Lead, Guid> _repository;
    private readonly LeadManager _leadManager;

    public LeadAppService(
        IGuidGenerator guidGenerator,
        IRepository<Lead, Guid> repository,
        LeadManager manager)
    {
        _guidGenerator = guidGenerator;
        _repository = repository;
        _leadManager = manager;
    }

    public async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
    {
        await _leadManager.PreventDuplicateEmailAndPhone([input.Email, input.Phone]); //Pure business logic
        
        var address = new Address(input.Street, input.City, input.State, input.ZipCode);
        var contactInfo = new ContactInfo(input.Phone, input.Email);
        var lead = new Lead(
            id: _guidGenerator.Create(),
            firstName: input.FirstName,
            lastName: input.LastName,
            contactInfo: contactInfo,
            address: address,
            company: input.Company,
            industry: input.Industry,
            source: input.Source,
            status: input.Status
        );
        
        var inserted = await _repository.InsertAsync(lead);
        var dto = ObjectMapper.Map<Lead, LeadDto>(inserted);
        dto.Street = inserted.Address.Street;
        dto.City = inserted.Address.City;
        dto.State = inserted.Address.State;
        dto.ZipCode = inserted.Address.ZipCode;
        
        return dto;
    }
    
    //GetAllLeads Used in js file via (Dynamic JS Proxies)
    public async Task<PagedResultDto<LeadDto>> GetAllLeadsAsync()
    {
        var leads = await _repository.GetListAsync();
        List<LeadDto> leadDtos = new();
        
        foreach (var lead in leads)
        {
            leadDtos.Add(
                new LeadDto
                {
                    Id = lead.Id,
                    FirstName = lead.FirstName, LastName = lead.LastName,
                    Email = lead.ContactInfo.Email, Phone = lead.ContactInfo.PhoneNumber,
                    Street = lead.Address.Street, City = lead.Address.City,
                    State = lead.Address.State, ZipCode = lead.Address.ZipCode,
                    Industry = lead.Industry, Company = lead.Company,
                    Source = lead.Source, Status = lead.Status 
                });
        }
        
        return new PagedResultDto<LeadDto>(leads.Count, leadDtos);
    }
    
    public async Task<LeadDto> FindLeadDtoAsync(Guid leadId)
    {
        Lead lead = await _repository.GetAsync(leadId);
       
        LeadDto dto = ObjectMapper.Map<Lead, LeadDto>(lead);
        dto.Phone = lead.ContactInfo.PhoneNumber;
        dto.Email = lead.ContactInfo.Email;
        dto.Street = lead.Address.Street;
        dto.City = lead.Address.City;
        dto.State = lead.Address.State;
        dto.ZipCode = lead.Address.ZipCode;
        
        return dto;
    }
    
    public async Task UpdateLeadAsync(Guid id, CreateUpdateLeadDto input)
    {
        var lead = await _repository.GetAsync(id);
        UpdateLeadMembers(lead, input);
        
        ObjectMapper.Map(input, lead);
    }

    //DeleteLead Used in js file via (Dynamic JS Proxies)
    public async Task DeleteLeadAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    private void UpdateLeadMembers(Lead lead, CreateUpdateLeadDto input)
    {
        lead.Rename(input.FirstName, input.LastName);
        lead.UpdateContacts(new ContactInfo(input.Phone, input.Email));
        lead.ChangeAddress(new Address(input.Street, input.City, input.State, input.ZipCode));
        lead.UpdateCompanyAndIndustry(input.Company, input.Industry);
        lead.ChangeStatus(input.Status);
        lead.ChangeSource(input.Source);
    }
}