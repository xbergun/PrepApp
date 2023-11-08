using NTT.Core.Entity.Base;
using NTT.Core.Enum;

namespace NTT.Core.Entity;

public class UserRole : BaseEntity
{
    public string RoleType { get; set; } = UserRoleEnum.User.ToString();

    public int UserId { get; set; } // Foreign Key
    // Navigation Properties
    public User User { get; set; } = null!;
}