/*
using NTT.Core.Repositories;
using NTT.Core.Services;
using NTT.Service.Models.UserRoles;

namespace NTT.Service.Implementations;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request)
    {
        UserRoleGetByIdRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        return  _userRoleRepository.WhereWithSelect(x => Equals(x.UserId, request.UserId), x => new UserRoleResponse
        {
            Id = x.RoleId,
            UserId = x.UserId,
            RoleType = x.RoleId.ToString(),
        }).Result;
        
    }

    public async Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request)
    {
        
        UserRoleCreateRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        var userRole = await _userRoleRepository.AddUserRoleAsync(request);

        return new UserRoleResponse
        {
            Id = userRole.Id,
            UserId = userRole.UserId,
            RoleType = userRole.RoleType,
        };

        
    }

    // Business Logics

 
    
}
*/