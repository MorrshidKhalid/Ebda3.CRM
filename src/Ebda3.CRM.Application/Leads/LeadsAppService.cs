using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ebda3.CRM.Repositories;
using Ebda3.CRM.ValueObjects;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Ebda3.CRM.Leads;

public class LeadsAppService : ApplicationService, ILeadsAppService
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<Lead, Guid> _repository;
    private readonly ILeadRepository _leadRepository;

    public LeadsAppService(
        IGuidGenerator guidGenerator, IRepository<Lead, Guid> repository,
        ILeadRepository leadRepository)
    {
        _guidGenerator = guidGenerator;
        _repository = repository;
        _leadRepository = leadRepository;
    }

    public async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
    {
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

    public async Task<List<LeadDto>> GetAllLeadsAsync()
    {
        var leads = await _leadRepository.GetAllAsync();
        
        return ObjectMapper.Map<List<Lead>, List<LeadDto>>(leads);
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