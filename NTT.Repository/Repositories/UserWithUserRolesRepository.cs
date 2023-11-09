using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Repository.Context;

namespace NTT.Repository.Repositories;

public class UserWithUserRolesRepository : GenericRepository<User> , IUserWithUserRolesRepository
{
    public UserWithUserRolesRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<User>> GetUserWithUserRolesAsync()
    {
        return await _context.Users.Include(x => x.UserRoles).ToListAsync();
    }
}