using Microsoft.AspNetCore.Identity;
namespace NTT.Core.Entity;
public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string TcNo { get; set; } = null!;
}