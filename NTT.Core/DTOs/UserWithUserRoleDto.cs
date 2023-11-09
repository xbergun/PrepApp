namespace NTT.Core.DTOs;

public class UserWithUserRoleDto : UserDto
{
    public List<UserRoleDto>? UserRoles { get; set; }
}