using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Repository.Context;
using NTT.Service.Models.UserRoles;

namespace NTT.Repository.Repositories;
public class UserRoleRepository :GenericRepository<UserRole>,IUserRoleRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleRepository(AppDbContext dbContext, IUnitOfWork unitOfWork)  : base(dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<UserRoleResponse> AddUserRoleAsync(UserRoleCreateRequest request)
    {
        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleType = request.RoleType,
        };
        EntityEntry<UserRole> userRoleEntry = await _dbContext.UserRoles.AddAsync(userRole);

        await _unitOfWork.CommitAsync();
        
        return new UserRoleResponse
        {
            Id = userRoleEntry.Entity.Id,
            UserId = userRoleEntry.Entity.UserId,
            RoleType = userRoleEntry.Entity.RoleType,
        };
    }
    
    /*public async Task<List<UserRoleResponse>> GetUserRolesByUserIdAsync(UserRoleGetByIdRequest request)
   {
       return  WhereWithSelect(x => x.UserId == request.UserId, x => new UserRoleResponse
       {
           Id = x.Id,
           UserId = x.UserId,
           RoleType = x.RoleType,
       }).Result;

       return await _dbContext.UserRoles
           .Where(x => x.UserId == request.UserId)
           .Select(x => new UserRoleResponse
           {
               Id = x.Id,
               UserId = x.UserId,
               RoleType = x.RoleType,
           }).ToListAsync();
   }
   */

}
