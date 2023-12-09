using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NTT.Core.DTOs.Custom.Auth;
using NTT.Core.Entity;
using NTT.Service.Abstractions;

namespace NTT.Service.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;
    private  readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(IConfiguration configuration, ITokenService tokenService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
    {
        _configuration = configuration;
        _tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;
        
    }

    public async Task<TokenModel> LoginAsync(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);
        
        if (!result.Succeeded)
        {
            throw new Exception("Password is wrong");
        }
        
        var token = await _tokenService.CreateToken(_configuration,model);

        return token;
    }
}