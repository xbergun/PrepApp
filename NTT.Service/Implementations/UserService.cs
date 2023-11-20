using Microsoft.EntityFrameworkCore;
using NTT.Core.Entity;
using NTT.Core.Repositories;
using NTT.Core.UnitOfWorks;
using NTT.Service.Abstractions;
using NTT.Service.Models.Users;

namespace NTT.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }


    public async Task<UserResponse> UpdateAsync(UserUpdateRequest request)
    {
        //TODO: AUTH VALidation
        //TODO: Model Validation
        //TODO: Business Validation
        
        var user = await _repository.GetByIdAsync(request.Id);
        
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Username = request.Username;
        user.Email = request.Email;
        user.TcNo = request.TcNo;

        _repository.Update(user);
        
        await _unitOfWork.CommitAsync();
        
        return new UserResponse(user);
    }

    public async Task<bool> DeleteAsync(UserDeleteRequest request)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        _repository.Remove(user);

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<UserResponse> CreateAsync(UserCreateRequest request)
    {
        var user = request.ToEntity();

        await _repository.AddAsync(user);

        await _unitOfWork.CommitAsync();

        return new UserResponse(user);
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        return await _repository.GetAll().Select(x => new UserResponse()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Username = x.Username,
                TcNo = x.TcNo,
            })
            .ToListAsync();

    }

    public async Task<UserResponse> GetByIdAsync(UserGetByIdRequest request)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        return new UserResponse(user);
    }
    
}