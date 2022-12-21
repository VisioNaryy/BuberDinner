using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class FirstName : ValueObject
{
    public string Value { get; set; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName CreateNew(string value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}