using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public string Name { get; set; }
    public string Description { get; set; }

    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }
    
    public static MenuSection Create(string name, string description,  List<MenuItem> items) => new(MenuSectionId.CreateUniqie(), name, description, items);
}