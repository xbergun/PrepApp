using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.API.Filters;
using NTT.Core.DTOs;
using NTT.Core.DTOs.Custom;
using NTT.Core.Entity;
using NTT.Core.Services;

namespace NTT.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;
       
       

        public UsersController(IMapper mapper, IService<User> service)
        {
            _mapper = mapper;
            _service = service;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var users= await _service.GetAllAsync();
           
           var userDto = _mapper.Map<List<UserDto>>(users.ToList());
           
           return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200,userDto));
           
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            
            var userDto = _mapper.Map<UserDto>(user);
            
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200,userDto));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var newUser = await _service.AddAsync(_mapper.Map<User>(userDto));
            
            var newUserDto = _mapper.Map<UserDto>(newUser);
            
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201,newUserDto));
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await  _service.Update(_mapper.Map<User>(userDto));
            
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);
            
            await _service.Remove(user);
            
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200));
        }
        
     
       
    }
}
