using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Categories;

public class CreateUpdateCategoryDto : AuditedAggregateRoot<Guid>   
{
    [Required]
    [MaxLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}