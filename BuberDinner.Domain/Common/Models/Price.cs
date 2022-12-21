namespace BuberDinner.Domain.Common.Models;

public class Price : ValueObject
{
    public decimal Account { get; set; }

    public string Currency { get; set; }

    public Price(decimal account, string currency)
    {
        Account = account;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Account;
        yield return Currency;
    }
}