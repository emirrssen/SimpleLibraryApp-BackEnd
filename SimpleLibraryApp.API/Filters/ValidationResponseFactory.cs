using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Results;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.API;

public class ValidationResponseFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
    {
        return new BadRequestObjectResult(new {Title = "Validation errors", ValidationErrors = validationProblemDetails?.Errors});
    }

    public IResult CreateResult(EndpointFilterInvocationContext context, ValidationResult validationResult)
    {
        throw new NotImplementedException();
    }
}
