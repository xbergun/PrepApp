using NTT.Core.Entity;

namespace NTT.Core.Services;

public interface IUserWithUserRolesService : IService<User>
{
  Task<List<User>> GetUserWithUserRolesAsync();
  
}