using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    public string Value { get; set; }
    public string Addres { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    private Location(string value, string addres, float latitude, float longitude)
    {
        Value = value;
        Addres = addres;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location CreateNew(string value, string addres, float latitude, float longitude)
    {
        return new(value, addres,latitude,longitude);
    }    
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
        yield return Addres;
        yield return Latitude;
        yield return Longitude;
    }
}