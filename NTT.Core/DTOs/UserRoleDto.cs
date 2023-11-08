using NTT.Core.DTOs.Base;
using NTT.Core.Enum;

namespace NTT.Core.DTOs;

public class UserRoleDto : BaseDto
{
    public string RoleType { get; set; } = UserRoleEnum.User.ToString();

    public int UserId { get; set; } // Foreign Key

}