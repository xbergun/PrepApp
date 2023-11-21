namespace NTT.Service.Models.UserRoles;

public class UserRoleResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? RoleType { get; set; }
}