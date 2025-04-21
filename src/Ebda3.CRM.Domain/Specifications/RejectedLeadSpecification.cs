using System;
using System.Linq.Expressions;
using Ebda3.CRM.Leads;
using Volo.Abp.Specifications;

namespace Ebda3.CRM.Specifications;

public class RejectedLeadSpecification : Specification<Lead>
{
    public override Expression<Func<Lead, bool>> ToExpression()
    {
        throw new NotImplementedException("Rejected leads Specification are not implemented yet.");
    }
}