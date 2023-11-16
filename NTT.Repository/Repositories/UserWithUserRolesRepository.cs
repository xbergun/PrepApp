using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTT.Core.DTOs;
using NTT.Core.Entity;
using NTT.Core.Enum;
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

    public async Task<User?> GetUserWithUserRolesByIdAsync(int userId)
    {
        return await _context.Users.Include(x => x.UserRoles).SingleOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User> AddUserWithUserRolesAsync(User user)
    {
       var result =  await _context.Users.AddAsync(user);
       await _context.SaveChangesAsync();
       return user;
    }
}