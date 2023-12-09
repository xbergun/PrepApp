namespace NTT.Core.Entity;

public class ApplicationRefreshToken
{
    public Guid Id { get; set; }
    public Guid ApplicationUserId { get; set; }
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    
}