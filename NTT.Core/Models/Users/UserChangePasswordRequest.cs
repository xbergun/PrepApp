namespace NTT.Service.Models.Users;

public class UserChangePasswordRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}