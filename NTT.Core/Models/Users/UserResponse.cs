using NTT.Core.Entity;

namespace NTT.Service.Models.Users;

public class UserResponse
{
    public UserResponse()
    {
        
    }
    public UserResponse(ApplicationUser applicationUser)
    {
        if (applicationUser == null)
        {
            return;
        }

        Id = applicationUser.Id;
        FirstName = applicationUser.FirstName;
        LastName = applicationUser.LastName;
        UserName = applicationUser.UserName;
        Email = applicationUser.Email;
        TcNo = applicationUser.TcNo;
        PhoneNumber = applicationUser.PhoneNumber;
        
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string TcNo { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
}