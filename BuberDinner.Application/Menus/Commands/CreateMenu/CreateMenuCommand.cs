using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;
    
    
public record MenuSectionCommand
(
    string Name,
    string Description,
    List<MenuItemsCommand> Items
);

public record MenuItemsCommand
(
    string Name,
    string Description
);