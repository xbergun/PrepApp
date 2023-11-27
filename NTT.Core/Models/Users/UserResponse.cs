using NTT.Core.Entity;

namespace NTT.Service.Models.Users;

public class UserResponse
{
    public UserResponse()
    {
        
    }
    public UserResponse(User user)
    {
        if (user == null)
        {
            return;
        }

        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Email = user.Email;
        TcNo = user.TcNo;
    }
    

    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string TcNo { get; set; } = null!;
}