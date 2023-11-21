using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Service.Models.UserRoles;

namespace NTT.Repository.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleRepository(AppDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request)
    {
        var userRoles = await _dbContext.UserRoles
            .Where(x => x.UserId == request.UserId)
            .ToListAsync();
        return userRoles.Select(x => new UserRoleResponse
        {
            Id = x.Id,
            UserId = x.UserId,
            RoleType = x.RoleType,
        }).ToList();
    }
    

    public async Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request)
    {
        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleType = request.RoleType,
        };
        EntityEntry<UserRole> userRoleEntry = await _dbContext.UserRoles.AddAsync(userRole);
        await _dbContext.SaveChangesAsync();
        return new UserRoleResponse
        {
            Id = userRoleEntry.Entity.Id,
            UserId = userRoleEntry.Entity.UserId,
            RoleType = userRoleEntry.Entity.RoleType,
        };
    }

}
