using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    public DinnersController()
    {
        
    }

    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}