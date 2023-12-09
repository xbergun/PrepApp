namespace NTT.Core.DTOs.Custom.Auth;

public class TokenModel
{
    public Guid UserId { get; set; }
    
    public string AccessToken { get; set; } = null!;
    
    public DateTime AccessTokenExpirationDateTime { get; set; }
    
    public string RefreshToken { get; set; } = null!;
    
    public DateTime RefreshTokenExpirationDateTime { get; set; }

}