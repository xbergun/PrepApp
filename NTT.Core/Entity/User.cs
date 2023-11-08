using NTT.Core.Entity.Base;

namespace NTT.Core.Entity;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string TcNo { get; set; } = null!;
    
    // Navigation Properties
    public List<TelephoneNumber>? TelephoneNumbers { get; set; } 
    public List<UserRole>? UserRoles { get; set; }
}