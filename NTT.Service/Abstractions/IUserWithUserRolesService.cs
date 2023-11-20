using NTT.Core.DTOs;
using NTT.Core.Entity;

namespace NTT.Core.Services;

public interface IUserWithUserRolesService
{
  Task<List<User>> GetUserWithUserRolesAsync();
  
  Task<User?> GetUserWithUserRolesByIdAsync(int userId);
  
  Task<CreateUserWithUserRoleDto> AddUserWithUserRolesAsync(CreateUserWithUserRoleDto createUserWithUserRoleDto);


}