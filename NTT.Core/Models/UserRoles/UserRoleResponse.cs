namespace NTT.Service.Models.UserRoles;

public class UserRoleResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? RoleType { get; set; }
}