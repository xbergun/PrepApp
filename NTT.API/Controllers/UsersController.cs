using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs;
using NTT.Core.DTOs.Custom;
using NTT.Core.Entity;
using NTT.Core.Services;
using NTT.Service.Abstractions;
using NTT.Service.Models.Users;

namespace NTT.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            
            return CreateActionResult(CustomResponseDto<List<UserResponse>>.Success(200, users));
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]UserGetByIdRequest request)
        {
            var user = await _userService.GetByIdAsync(request);

            return CreateActionResult(CustomResponseDto<UserResponse>.Success(200, user));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateRequest request)
        {
            var newUser = await _userService.CreateAsync(request);
            return CreateActionResult(CustomResponseDto<UserResponse>.Success(201, newUser));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateRequest request)
        {
            var newUser = await _userService.UpdateAsync(request);

            return CreateActionResult(CustomResponseDto<UserResponse>.Success(200, newUser));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(UserDeleteRequest request)
        { 
          var isDeleted = await _userService.DeleteAsync(request);

        return CreateActionResult(CustomResponseDto<bool>.Success(200,isDeleted));
        }
        
        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);

            var userDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateUserDto createUserDto)
        {
            var newUser = await _service.AddAsync(_mapper.Map<User>(createUserDto));

            var newUserDto = _mapper.Map<UserDto>(newUser);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, newUserDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
              await _service.Update(_mapper.Map<User>(updateUserDto));

            return CreateActionResult(CustomResponseDto<UpdateUserDto>.Success(200, updateUserDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.Remove(user);

            return CreateActionResult(CustomResponseDto<DeleteUserDto>.Success(200, new DeleteUserDto()));
        }
        */
    }
    
}