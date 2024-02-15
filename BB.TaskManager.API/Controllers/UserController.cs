using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BB.TaskManager.API.Controllers;

[Route("[controller]/")]
public class UserController : Controller
{
    private readonly IAuthService _authService;
    
    public UserController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserModel createUserModel)
    {
        var result = await _authService.CreateAsync(createUserModel.Username, createUserModel.Email, createUserModel.Password);
        if (result is not null)
            return Ok(result);

        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserVm loginUserVm)
    {
        var token = await _authService.AuthenticateAsync(loginUserVm.Email, loginUserVm.Password);
        if (token != null)
            return Ok(token);

        return BadRequest();
    }
}