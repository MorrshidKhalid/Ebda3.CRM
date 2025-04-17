using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Ebda3.CRM.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    protected  Address()
    {
        //Required by the EF Core
    }

    public Address(string street, string city, string state, string zipCode)
    {
        bool isEmptyOrNull = !string.IsNullOrEmpty(street) || !string.IsNullOrEmpty(city) ||
                             !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(zipCode);

        if (isEmptyOrNull)
        {
            throw new ArgumentException("Address info cannot be empty or null");
        }
        
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        //(ToLower) to case-insensitive comparison
        yield return Street.ToLower(); 
        yield return City.ToLower(); 
        yield return State.ToLower(); 
        yield return ZipCode.ToLower(); 
    }
}