using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom;
using NTT.Core.Services;
using NTT.Service.Models.UserRoles;

namespace NTT.API.Controllers;

public class UserRoleController : BaseController
{
    private readonly  IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }
    
    [HttpGet("{UserId}")]
    public async Task<IActionResult> GetUserRoleByUserId([FromRoute]UserRoleGetByIdRequest request)
    {
        var userRoles = await _userRoleService.GetUserRolesByUserIdAsync(request).ConfigureAwait(false);
        return CreateActionResult(CustomResponseModel<List<UserRoleResponse>>.Success(200, userRoles));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUserRole(UserRoleCreateRequest request)
    {
        var newUserRole = await _userRoleService.AddUserRoleAsync(request).ConfigureAwait(false);
        return CreateActionResult(CustomResponseModel<UserRoleResponse>.Success(201, newUserRole));
    }
    
}