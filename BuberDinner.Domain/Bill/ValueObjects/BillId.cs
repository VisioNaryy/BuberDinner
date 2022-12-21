using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

public class BillId : ValueObject
{
    public Guid Value { get; set; }

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUniqie()
    {
        return new(Guid.NewGuid());
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}