namespace NTT.Core.DTOs.Custom.Auth;

public class LoginModel
{
    public required string Email { get; set; } = null!;
    public required string Password { get; set; }

}