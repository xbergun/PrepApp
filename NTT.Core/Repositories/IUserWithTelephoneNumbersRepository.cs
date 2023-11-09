using NTT.Core.Entity;

namespace NTT.Core.Repositories;

public interface IUserWithTelephoneNumbersRepository : IGenericRepository<User>
{
    Task<List<User>> GetUsersWithTelephoneNumbers();
}