using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTT.Core.DTOs;
using NTT.Core.DTOs.Custom;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Core.UnitOfWorks;

namespace NTT.Service.Services;

public class UserService : Service<User>, IUserService
{
    private readonly IUserWithUserRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserWithUserRolesRepository rolesRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }
    

    public async Task<List<User>> GetUserWithUserRolesAsync()
    {
        var users = await _rolesRepository.GetUserWithUserRolesAsync();
        return users;


    }
}