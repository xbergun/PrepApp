using NTT.Core.DTOs.Custom.Auth;

namespace NTT.Service.Abstractions;

public interface IAuthService
{
    Task<TokenModel> LoginAsync(LoginModel model);
}