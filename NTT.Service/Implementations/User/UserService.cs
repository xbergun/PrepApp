using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Service.Abstractions;
using NTT.Service.Models.Users;

namespace NTT.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<ApplicationUser> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public UserService(IGenericRepository<ApplicationUser> repository, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<UserResponse> UpdateAsync(UserUpdateRequest request)
    {
        //TODO: AUTH VALidation
        UserUpdateRequestValidator validator = new();
        await validator.ValidateAsync(request);
        //TODO: Business Validation
        
        var user = await _repository.GetByIdAsync(request.Id);
        
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.UserName = request.Username;
        user.Email = request.Email;
        user.TcNo = request.TcNo;

        _repository.Update(user);
        
        await _unitOfWork.CommitAsync();
        
        return new UserResponse(user);
    }

    public async Task<bool> DeleteAsync(UserDeleteRequest request)
    {
        UserDeleteRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        var user = await _repository.GetByIdAsync(request.Id);

        _repository.Remove(user);

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<UserResponse> CreateAsync(UserCreateRequest request)
    {
        //Validator
        UserCreateRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        var user = request.ToEntity();
        
        var result = await _userManager.CreateAsync(user, request.Password);

        if (result?.Succeeded != true)
        {
            throw new Exception("Kullanıcı oluşturulamadı");
        }
        
        var isCheckRole = await _roleManager.RoleExistsAsync("Admin");

        if (!isCheckRole)
        {
            var role = new ApplicationRole();
            
            role.Name = "Admin";
            
            await _roleManager.CreateAsync(role);

        }
        
        var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
        
        if (roleResult?.Succeeded != true)
        {
            throw new Exception("role not created");
        }
        
        
        
        return new UserResponse(user);
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        return await _repository.GetAll().Select(x => new UserResponse()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                TcNo = x.TcNo,
            })
            .ToListAsync();

    }

    public async Task<UserResponse> GetByIdAsync(UserGetByIdRequest request)
    {
        UserGetByIdRequestValidator validator = new();
        await validator.ValidateAsync(request);
        
        var user = await _repository.GetByIdAsync(request.Id);
        return new UserResponse(user);
    }
    
    
    
}