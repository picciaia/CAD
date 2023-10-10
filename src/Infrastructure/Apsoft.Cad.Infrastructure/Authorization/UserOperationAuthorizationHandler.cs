using Apsoft.Cad.Application;
using Microsoft.AspNetCore.Authorization;

namespace Apsoft.Cad.Infrastructure;

public class UserOperationAuthorizationHandler : AuthorizationHandler<UserOperationAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOperationAuthorizationRequirement requirement)
    {
        switch (requirement.Name)
        {
            case Operations.CREATE:
            case Operations.EDIT:
            case Operations.DELETE:
            case Operations.READ:
                context.EvaluateRequirement(requirement,
                    () =>
                    true
                    //context.User.IsInRole(Roles.Admin.ToString())
                    );
                break;
        }
        return Task.CompletedTask;

    }
}
