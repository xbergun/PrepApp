using NTT.Core.DTOs;
using NTT.Core.Entity;

namespace NTT.Core.Repositories;

public interface IUserWithUserRolesRepository : IGenericRepository<User>
{
    Task<List<User>> GetUserWithUserRolesAsync();
    Task<User?> GetUserWithUserRolesByIdAsync(int userId);
    Task<User> AddUserWithUserRolesAsync(User user);
}