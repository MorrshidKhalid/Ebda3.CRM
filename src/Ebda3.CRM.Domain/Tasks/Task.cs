using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ebda3.CRM.Tasks;

public class Task : FullAuditedAggregateRoot<Guid>
{
}