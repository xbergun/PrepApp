using NTT.Core.Entity;

namespace NTT.Core.Services;

public interface IUserWithTelephoneNumbersService : IService<User>
{
    Task<List<User>> GetUserWithTelephoneNumbersAsync();
}