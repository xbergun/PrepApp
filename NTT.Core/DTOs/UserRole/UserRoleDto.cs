using System.Text.Json.Serialization;
using NTT.Core.Enum;

namespace NTT.Core.DTOs;

public class UserRoleDto
{
    public string RoleType { get; set; } = UserRoleEnum.User.ToString();
    [JsonIgnore]
    public int UserId { get; set; } // Foreign Key
}