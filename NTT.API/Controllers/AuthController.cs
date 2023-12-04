using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom.Auth;
using NTT.Service.Abstractions;

namespace NTT.API.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
        
    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }
    [HttpPost("Login")] 
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await _authService.LoginAsync(loginModel);
        return Ok(token);
    }
    
    [Authorize]
   // [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> WhoIAm()
    {
       // if (!User.Identity.IsAuthenticated)
        //{
         //  return Unauthorized();
        //}

        //if (!User.IsInRole("Admin"))
        //{
         //   return Forbid();
        //}
        
        var email = User.Identity?.Name;
        return Ok(email);
    }
}