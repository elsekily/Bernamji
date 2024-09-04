using Bernamji.Application.Resources;
using Bernamji.Application.Services.Core;
using Bernamji.Application.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bernamji.Controllers.API;
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
    public async Task<IActionResult> Login([FromBody]UserResource user)
    {
        if (user == null)
            return BadRequest();

        var result = await userService.CheckUserCredentials(user);

        if (!result.IsSuccess)
            return Unauthorized(result);

        return Ok(result);
    }
}
