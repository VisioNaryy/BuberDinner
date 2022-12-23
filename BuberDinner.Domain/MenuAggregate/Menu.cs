using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu: AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    
    public string Name { get; set; }
    public string Description { get; set; }
    public AverageRating AverageRating { get; set; }
    public HostId HostId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private Menu(MenuId id, string name, string description, HostId hostId, List<MenuSection> sections, AverageRating averageRating, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections, AverageRating averageRating)
        => new(
            MenuId.CreateUniqie(),
            name,
            description,
            hostId,
            sections,
            averageRating,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

}