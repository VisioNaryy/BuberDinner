using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class MaxGuests : ValueObject
{
    public int Value { get; set; }

    private MaxGuests(int value)
    {
        Value = value;
    }

    public static MaxGuests CreateNew(int value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}