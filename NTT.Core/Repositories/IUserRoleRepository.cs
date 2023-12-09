using NTT.Core.Entity;
using NTT.Service.Models.UserRoles;

namespace NTT.Core.Repositories;

public interface IUserRoleRepository : IGenericRepository<ApplicationUserRole>
{
    //Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request);
    Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request);
}
