using Volo.Abp;

namespace Ebda3.CRM.Exceptions;

public class PhoneNumberTakenException : BusinessException
{
    public PhoneNumberTakenException(string phoneNumber) 
        : base(CRMDomainErrorCodes.PhoneNumberAlreadyTaken)
    {
        WithData(nameof(phoneNumber), phoneNumber);
    }
}