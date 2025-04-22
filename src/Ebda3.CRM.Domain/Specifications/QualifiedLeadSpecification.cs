using System;
using System.Linq.Expressions;
using Ebda3.CRM.Leads;
using Volo.Abp.Specifications;

namespace Ebda3.CRM.Specifications;

public class QualifiedLeadSpecification : Specification<Lead>
{
    public override Expression<Func<Lead, bool>> ToExpression()
    {
        return l => l.Status == LeadStatus.Qualified;
    }
}