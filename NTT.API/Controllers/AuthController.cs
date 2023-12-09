using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom.Auth;
using NTT.Core.Enum;
using NTT.Service.Abstractions;

namespace NTT.API.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
        
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("Login")] 
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await _authService.LoginAsync(loginModel);
        return Ok(token);
    }
    
    [Authorize]
    [Authorize(Roles = nameof(UserRoleEnum.Admin))]
    [HttpGet("WhoIAm")]
    public async Task<IActionResult> WhoIAm()
    {
        var email = User.Identity?.Name;
        return Ok(email);
    } 
   
}