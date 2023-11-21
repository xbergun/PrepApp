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
        
        return await _userRoleRepository.GetUserRolesByUserIdAsync(request);
    }

    public async Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request)
    {
        
        UserRoleCreateRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        var userRole = await _userRoleRepository.AddUserRoleAsync(request);

        var userRoleResponse = new UserRoleResponse
        {
            Id = userRole.Id,
            UserId = userRole.UserId,
            RoleType = userRole.RoleType,
            // Diğer özellikleri ekleyin
        };

        return userRoleResponse;
    }

    
}
