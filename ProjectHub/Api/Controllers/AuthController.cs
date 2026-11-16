using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        if (request.Password != request.PasswordConfirm)
        {
            ModelState.AddModelError(nameof(UserRegisterRequest.PasswordConfirm), "Passwords do not match.");
            return ValidationProblem(ModelState);
        }

        var result = await authService.RegisterAsync(request);
        if (result.Succeeded)
            return Ok();

        foreach (var error in result.Errors)
            ModelState.AddModelError(error.Code, error.Description);

        return ValidationProblem(ModelState);
    } 
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authService.LoginAsync(request);
        return result is not null ? Ok(result) : Unauthorized();
    }
}
