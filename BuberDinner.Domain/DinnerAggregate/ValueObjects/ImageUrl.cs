using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class ImageUrl : ValueObject
{
    public string Value { get; set; }

    private ImageUrl(string value)
    {
        Value = value;
    }

    public static ImageUrl CreateNew(string value)
    {
        return new(value);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}