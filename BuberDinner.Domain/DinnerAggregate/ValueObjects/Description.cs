using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Description : ValueObject
{
    public string Value { get; set; }

    private Description(string value)
    {
        Value = value;
    }

    public static Description CreateNew(string value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}