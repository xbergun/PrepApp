using NTT.Core.Entity.Base;

namespace NTT.Core.Entity;

public class TelephoneNumber : BaseEntity
{
    public string? TelNo { get; set; }
 
    public int UserId { get; set; } // Foreign Key
    // Navigation Properties
    public User User { get; set; } = null!;
}