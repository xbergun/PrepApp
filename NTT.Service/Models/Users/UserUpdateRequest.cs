using NTT.Core.Entity;

namespace NTT.Service.Models.Users;

public class UserUpdateRequest
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Username { get; set; }

    public string Email { get; set; }
    
    public string TcNo { get; set; }
    
    
}