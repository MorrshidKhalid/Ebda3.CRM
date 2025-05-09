using System;
using Volo.Abp.Application.Dtos;

namespace Ebda3.CRM.Categories;

public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
}