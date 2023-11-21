using Microsoft.AspNetCore.Mvc;
using NTT.Core.DTOs.Custom;
using NTT.Core.Enum;

namespace NTT.API.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseModel<T> responseModel)
    {
       return responseModel.StatusCode switch
       {
              (int)StatusCodeEnum.Success => Ok(responseModel),
              (int)StatusCodeEnum.BadRequest => BadRequest(responseModel),
              (int)StatusCodeEnum.NoContent => NoContent(),
              (int)StatusCodeEnum.Created => Created("", responseModel),
              _ => BadRequest(responseModel)
         };
       }

    }
