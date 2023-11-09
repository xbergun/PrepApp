using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;

namespace NTT.Service.Services;

public class UserWithTelephoneNumbersService : Service<User>, IUserWithTelephoneNumbersService
{
    private readonly IUserWithTelephoneNumbersRepository _telephoneNumbersRepository;

    public UserWithTelephoneNumbersService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserWithTelephoneNumbersRepository telephoneNumbersRepository) : base(repository, unitOfWork)
    {
        _telephoneNumbersRepository = telephoneNumbersRepository;
    }
    
    public async Task<List<User>> GetUserWithTelephoneNumbersAsync()
    {
        var users = await _telephoneNumbersRepository.GetUsersWithTelephoneNumbers();
        return users;
    }
}