using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Common;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers;

[Route("auth/[action]")]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var (firstName, lastName, email, password) = request;
        
        var command = new RegisterCommand(firstName, lastName, email, password);

        var registerResult = await _sender.Send(command);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));

        //Using Fluent errors
        // if (registerResult.IsSuccess)
        //     return Ok(MapAuthResult(registerResult.Value));
        //
        // var firstError = registerResult.Errors.FirstOrDefault();
        //
        // if (firstError is DuplicateEmailError)
        //     return Problem(statusCode: StatusCodes.Status409Conflict, title:"Email already exists.");
        //
        // return Problem();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var (email, password) = request;

        var query = new LoginQuery(email, password);

        var loginResult = await _sender.Send(query);

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return response;
    }
}