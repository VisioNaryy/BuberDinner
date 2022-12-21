using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<DinnerReservation> _reservations = new();

    public Name Name { get; set; }
    public Description Description { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime? StartedDateTime { get; set; }
    public DateTime? EndedDateTime { get; set; }

    public Status Status { get; set; }
    public bool IsPublic { get; set; }
    public MaxGuests MaxGuests { get; set; }
    public Price Price { get; set; }

    public HostId HostId { get; set; }
    public MenuId MenuId { get; set; }

    public ImageUrl ImageUrl { get; set; }
    public Location Location { get; set; }

    public IReadOnlyList<DinnerReservation> DinnerReservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }


    private Dinner(DinnerId id, Name name, Description description, DateTime startDateTime, DateTime endDateTime,
        DateTime? startedDateTime, DateTime? endedDateTime, Status status, bool isPublic, MaxGuests maxGuests,
        Price price, HostId hostId, MenuId menuId, ImageUrl imageUrl, Location location, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Dinner CreateNew(Name name, Description description, DateTime startDateTime, DateTime endDateTime,
        DateTime? startedDateTime, DateTime? endedDateTime, Status status, bool isPublic, MaxGuests maxGuests,
        Price price, HostId hostId, MenuId menuId, ImageUrl imageUrl, Location location) =>
        new(DinnerId.CreateUniqie(), name, description, startDateTime, endDateTime, startedDateTime, endedDateTime,
            status, isPublic, maxGuests, price, hostId, menuId, imageUrl, location, DateTime.UtcNow, DateTime.UtcNow);
}