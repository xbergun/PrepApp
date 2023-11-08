using Microsoft.AspNetCore.Mvc;
using NTT.Core.DTOs.Custom;
using NTT.Core.Enum;

namespace NTT.API.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> responseDto)
    {
       return responseDto.StatusCode switch
       {
              (int)StatusCodeEnum.Success => Ok(responseDto),
              (int)StatusCodeEnum.BadRequest => BadRequest(responseDto),
              (int)StatusCodeEnum.NoContent => NoContent(),
              (int)StatusCodeEnum.Created => Created("", responseDto),
              _ => BadRequest(responseDto)
         };
       }

    }
