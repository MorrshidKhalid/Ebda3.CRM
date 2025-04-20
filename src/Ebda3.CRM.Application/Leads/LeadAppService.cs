using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ebda3.CRM.Repositories;
using Ebda3.CRM.Services;
using Ebda3.CRM.ValueObjects;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Ebda3.CRM.Leads;

public class LeadAppService : ApplicationService, ILeadAppService
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<Lead, Guid> _repository;
    private readonly ILeadRepository _leadRepository;
    private readonly LeadDomainServiceImpl _leadDomainServiceImpl;

    public LeadAppService(
        IGuidGenerator guidGenerator, IRepository<Lead, Guid> repository,
        ILeadRepository leadRepository,
        LeadDomainServiceImpl domainServiceImpl)
    {
        _guidGenerator = guidGenerator;
        _repository = repository;
        _leadRepository = leadRepository;
        _leadDomainServiceImpl = domainServiceImpl;
    }

    public async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
    {
        await _leadDomainServiceImpl.IsEmailTaken(input.Email); //Pure business logic
        
        var address = new Address(input.Street, input.City, input.State, input.ZipCode);
        var lead = new Lead(
            id: _guidGenerator.Create(),
            firstName: input.FirstName,
            lastName: input.LastName,
            email: input.Email,
            phone: input.Phone,
            address: address,
            camponey: input.Camponey,
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
    public async Task<LeadDto> GetLeadById(Guid leadId)
    {
        Lead? foundedLead = null;
        try
        {
            foundedLead = await _leadRepository.FindByIdAsync(leadId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       

        return foundedLead == null ? new LeadDto() : ObjectMapper.Map<Lead, LeadDto>(foundedLead);
    }
    public async Task<PagedResultDto<LeadDto>> GetAllLeadsAsync()
    {
        var leads = await _leadRepository.FindAllAsync();
        List<LeadDto> leadDtos = new();
        
        foreach (var lead in leads)
        {
            leadDtos.Add(
                new LeadDto
                {
                    Id = lead.Id,
                    FirstName = lead.FirstName, LastName = lead.LastName, Email = lead.Email,
                    Phone = lead.Phone, Street = lead.Address.Street, City = lead.Address.City,
                    State = lead.Address.State, ZipCode = lead.Address.ZipCode,
                    Industry = lead.Industry, Camponey = lead.Camponey,
                    Source = lead.Source, Status = lead.Status 
                });
        }
        
        return new PagedResultDto<LeadDto>(leads.Count, leadDtos);
    }
    public async Task DeleteLeadByStatusAsync(LeadStatus status)
    {
        await _leadRepository.DeleteLeadByStatusAsync(status);
    }
    public async Task DeleteLeadBySourceAsync(LeadSource source)
    {
        await _leadRepository.DeleteLeadBySourceAsync(source);
    }
}