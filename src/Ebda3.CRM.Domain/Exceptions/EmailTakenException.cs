using Volo.Abp;

namespace Ebda3.CRM.Exceptions;

public class EmailTakenException : BusinessException
{
    public EmailTakenException(string emailAddress) : base(CRMDomainErrorCodes.EmailAlreadyTaken)
    {
        WithData(nameof(emailAddress), emailAddress);
    }
}