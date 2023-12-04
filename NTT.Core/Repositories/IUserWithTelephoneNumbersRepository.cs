using NTT.Core.Entity;

namespace NTT.Core.Repositories;

public interface IUserWithTelephoneNumbersRepository : IGenericRepository<ApplicationUser>
{
    Task<List<ApplicationUser>> GetUsersWithTelephoneNumbers();
}