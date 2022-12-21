using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class ProfileImage : ValueObject
{
    public string Value { get; set; }

    private ProfileImage(string value)
    {
        Value = value;
    }

    public static ProfileImage CreateNew(string value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}