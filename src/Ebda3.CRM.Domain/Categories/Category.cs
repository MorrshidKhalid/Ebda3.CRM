using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Categories;

public class Category : AuditedAggregateRoot<Guid> 
{
    public string Name { get; set; }
}