using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class LastName : ValueObject
{
    public string Value { get; set; }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName CreateNew(string value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}