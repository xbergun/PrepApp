using NTT.Core.DTOs;
using NTT.Core.Entity;
using NTT.Service.Models.UserRoles;

namespace NTT.Core.Services;

public interface IUserRoleService
{
  Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request);
  
  Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request);
}