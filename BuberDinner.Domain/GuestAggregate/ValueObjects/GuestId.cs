using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUniqie()
    {
        return new(Guid.NewGuid());
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}