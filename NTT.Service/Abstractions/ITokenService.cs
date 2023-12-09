using Microsoft.Extensions.Configuration;
using NTT.Core.DTOs.Custom.Auth;

namespace NTT.Service.Abstractions;

public interface ITokenService
{
    Task<TokenModel> CreateToken(IConfiguration configuration, LoginModel loginModel);
    
}