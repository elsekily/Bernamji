using Bernamji.Application.Services.Core;
using Bernamji.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bernamji.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserResource user)
    {
        if (user == null)
            return BadRequest();

        var result = await userService.CheckUserCredentials(user);

        if (!result.IsSuccess)
            return Unauthorized(result);

        return Ok(result);
    }

    [HttpPost("Test")]
    public async Task<IActionResult> Test([FromBody] TestResource test)
    {
        return Ok(test);
    }
}
