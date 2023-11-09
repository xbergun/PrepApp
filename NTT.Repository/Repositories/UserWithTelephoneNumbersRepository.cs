using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Repository.Context;

namespace NTT.Repository.Repositories;

public class UserWithTelephoneNumbersRepository : GenericRepository<User>, IUserWithTelephoneNumbersRepository
{
    public UserWithTelephoneNumbersRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<User>> GetUsersWithTelephoneNumbers()
    {
        return await _context.Users.Include(x => x.TelephoneNumbers).ToListAsync();
    }
}