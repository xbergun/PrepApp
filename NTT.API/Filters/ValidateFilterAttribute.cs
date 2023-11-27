using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NTT.Core.DTOs.Custom;

namespace NTT.API.Filters;

public class ValidateFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

            context.Result = new BadRequestObjectResult(CustomResponseModel<List<string>>.Error(400, errors));
        }
    }
}