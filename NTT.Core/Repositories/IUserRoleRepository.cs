using NTT.Core.DTOs;
using NTT.Core.Entity;
using NTT.Service.Models.UserRoles;

namespace NTT.Core.Repositories;

public interface IUserRoleRepository{
    Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request);
    Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request);
}
