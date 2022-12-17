using BuberDinner.Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers;

[Route("auth/[action]")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerResult =
            _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

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

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginResult =
            _authenticationService.Login(request.Email, request.Password);

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
            );
    }
}