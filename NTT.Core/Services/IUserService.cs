using NTT.Core.Entity;

namespace NTT.Core.Services;

public interface IUserService : IService<User>
{
  Task<List<User>> GetUserWithUserRolesAsync();
}