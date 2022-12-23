using BuberDinner.Application.Menus.Commands.CreateMenu;
using Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers;

[Route("hosts/{hostId}/menus")]
[AllowAnonymous]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public MenusController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _sender.Send(command);

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }
}