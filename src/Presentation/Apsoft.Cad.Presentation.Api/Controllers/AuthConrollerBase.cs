using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apsoft.Cad.Presentation.Api.Controllers;

public abstract class AuthConrollerBase : ControllerBase
{
    protected readonly IAuthorizationService _authorizationService;


    public AuthConrollerBase(IAuthorizationService authorizationService) => _authorizationService = authorizationService;


    protected async Task<IActionResult> WhenAuthorized(IAuthorizationRequirement requirement,
               Task<IActionResult> action) =>
           (await IsAuthorized(requirement))
           ? await action
           : base.Unauthorized();

    protected async Task<IActionResult> WhenAuthorized(IAuthorizationRequirement requirement,
               IActionResult action) =>
           (await IsAuthorized(requirement))
           ? action
           : base.Unauthorized();

    protected async Task<bool> IsAuthorized(IAuthorizationRequirement requirement) =>
        (await _authorizationService.AuthorizeAsync(User, null, requirement)).Succeeded;



    protected IActionResult GetInternalServerErrorResult(object value) =>
        new ObjectResult(value) { StatusCode = StatusCodes.Status500InternalServerError };

    protected IActionResult GetGenericErrorResult(Exception ex) =>
        ex is AggregateException aggregate ? GetInternalServerErrorResult(aggregate.InnerExceptions)
        : GetInternalServerErrorResult(ex);

    protected IActionResult GetNoContentResult() => new NoContentResult();



    protected IActionResult GetNotFoundResult() => new NotFoundResult();

}
