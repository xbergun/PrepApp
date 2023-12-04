using Microsoft.AspNetCore.Identity;
using NTT.Core.Entity.Base;
namespace NTT.Core.Entity;
public class ApplicationUser : IdentityUser<Guid>
{
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string TcNo { get; set; } = null!;
    
}