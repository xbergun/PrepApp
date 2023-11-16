using AutoMapper;
using NTT.Core.DTOs;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;

namespace NTT.Service.Services;

public class UserWithUserRolesService : Service<User>, IUserWithUserRolesService
{
    private readonly IUserWithUserRolesRepository _rolesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserWithUserRolesService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserWithUserRolesRepository rolesRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _rolesRepository = rolesRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<List<User>> GetUserWithUserRolesAsync()
    {
        var users = await _rolesRepository.GetUserWithUserRolesAsync();
        return users;
    }

    public async Task<User?> GetUserWithUserRolesByIdAsync(int userId)
    {
        var user = await _rolesRepository.GetUserWithUserRolesByIdAsync(userId);
        return user;
    }

    public async Task<CreateUserWithUserRoleDto> AddUserWithUserRolesAsync(CreateUserWithUserRoleDto createUserWithUserRoleDto)
    {
        var userEntity = _mapper.Map<User>(createUserWithUserRoleDto);
        await _rolesRepository.AddUserWithUserRolesAsync(userEntity);
        return createUserWithUserRoleDto;
    }
}