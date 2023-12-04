using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NTT.Core.DTOs.Custom.Auth;
using NTT.Core.Entity;
using NTT.Service.Abstractions;

namespace NTT.Service.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public TokenService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<TokenModel> CreateToken(IConfiguration configuration, LoginModel loginModel)
    {
        TokenModel tokenModel = new();
    
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
    
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
    
        tokenModel.AccessTokenExpirationDateTime = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:AccessTokenExpiration"]));
    
        tokenModel.RefreshTokenExpirationDateTime = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:RefreshTokenExpiration"]));

        var user = await _userManager.FindByEmailAsync(loginModel.Email);

        var roles = await _userManager.GetRolesAsync(user);
        
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
    
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            configuration["Token:Issuer"],
            configuration["Token:Audience"],
            claims: claims,
            expires: tokenModel.AccessTokenExpirationDateTime,
            signingCredentials: signingCredentials
        );
    
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    
        tokenModel.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
    
        CreateRefreshToken(configuration, tokenModel);
    
        return tokenModel;
    }

    private static TokenModel CreateRefreshToken(IConfiguration configuration, TokenModel tokenModel)
    {
        byte[] randomNumber = new byte[32];
        
        using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        
        randomNumberGenerator.GetBytes(randomNumber);
        
        tokenModel.RefreshToken  = Convert.ToBase64String(randomNumber);
        
        return tokenModel;
        
    }
}