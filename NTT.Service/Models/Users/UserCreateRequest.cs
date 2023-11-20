using NTT.Core.Entity;

namespace NTT.Service.Models.Users;

public class UserCreateRequest
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string TcNo { get; set; } = null!;

    public  User ToEntity() => new User
    {
        FirstName = FirstName,
        LastName = LastName,
        Username = Username,
        Email = Email,
        TcNo = TcNo
    };
    
}