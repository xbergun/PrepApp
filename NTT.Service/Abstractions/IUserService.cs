using NTT.Core.Entity;
using NTT.Service.Models.Users;

namespace NTT.Service.Abstractions;

public interface IUserService
{
    Task<UserResponse> UpdateAsync(UserUpdateRequest request);
    
    Task<bool> DeleteAsync(UserDeleteRequest request);
    
    Task<UserResponse> CreateAsync(UserCreateRequest request);
    
    Task<List<UserResponse>> GetAllAsync();
    
    Task<UserResponse> GetByIdAsync(UserGetByIdRequest request);
}