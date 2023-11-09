using NTT.Core.Entity;

namespace NTT.Core.Repositories;

public interface IUserWithUserRolesRepository : IGenericRepository<User>
{
    Task<List<User>> GetUserWithUserRolesAsync();
}