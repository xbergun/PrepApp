namespace NTT.Core.DTOs;

public class CreateUserWithUserRoleDto : UserDto
{
    public List<UserRoleDto>? UserRoles { get; set; }
}