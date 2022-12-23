using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var (hostId, name, description, sections) = request;

        var menu = Menu.Create(
            name,
            description,
            HostId.Create(hostId),
            sections.ConvertAll(x => MenuSection.Create(
                x.Name,
                x.Description,
                x.Items.ConvertAll(x =>
                MenuItem.Create(x.Name, x.Description))
                )),
            AverageRating.CreateNew()
        );

        _menuRepository.Add(menu);
        
        return menu;
    }
}