using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace Ebda3.CRM.ValueObjects;

public class ContactInfo : ValueObject
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    protected ContactInfo()
    {
        // Required by EF Core.
    }
    
    public ContactInfo(string phoneNumber, string email)
    {
        Check.NotNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
        Check.NotNullOrWhiteSpace(email, nameof(email));
        
        PhoneNumber = phoneNumber;
        Email = email;
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        //(ToLower) to case-insensitive comparison
        yield return PhoneNumber.ToLower();
        yield return Email.ToLower();
    }
}