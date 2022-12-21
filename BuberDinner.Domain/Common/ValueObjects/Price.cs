using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Price : ValueObject
{
    public float Amount { get; set; }
    public string Currency { get; set; }

    private Price(float amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price CreateNew(float amount = 0, string currency = "USD")
    {
        return new(amount, currency);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}