using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom;
using NTT.Service.Abstractions;
using NTT.Service.Models.Users;

namespace NTT.API.Controllers
{
    public class UsersController : BaseController
    {
      
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            
            return CreateActionResult(CustomResponseModel<List<UserResponse>>.Success(200, users));
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]UserGetByIdRequest request)
        {
            var user = await _userService.GetByIdAsync(request);

            return CreateActionResult(CustomResponseModel<UserResponse>.Success(200, user));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateRequest request)
        {
            var newUser = await _userService.CreateAsync(request);
            return CreateActionResult(CustomResponseModel<UserResponse>.Success(201, newUser));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateRequest request)
        {
            var newUser = await _userService.UpdateAsync(request);

            return CreateActionResult(CustomResponseModel<UserResponse>.Success(200, newUser));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(UserDeleteRequest request)
        { 
          var isDeleted = await _userService.DeleteAsync(request);

        return CreateActionResult(CustomResponseModel<bool>.Success(200,isDeleted));
        }
        
    }
    
}