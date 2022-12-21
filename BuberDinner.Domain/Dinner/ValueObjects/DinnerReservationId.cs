using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerReservationId : ValueObject
{
    public Guid Value { get; set; }

    private DinnerReservationId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservationId CreateUniqie()
    {
        return new(Guid.NewGuid());
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}