using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    public Guid Value { get; set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUniqie()
    {
        return new(Guid.NewGuid());
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}