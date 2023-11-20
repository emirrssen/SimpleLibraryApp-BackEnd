using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.API;

public class ValidationResponseFilter: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            var result = ResponseFactory.FailResponse(string.Join(", ", errors));
            context.Result = new BadRequestObjectResult(result);
        }
    }
}
