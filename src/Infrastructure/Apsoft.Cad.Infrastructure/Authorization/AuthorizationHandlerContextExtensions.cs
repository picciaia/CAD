using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace Apsoft.Cad.Infrastructure;

public static class AuthorizationHandlerContextExtensions
{
    public static void EvaluateRequirement(this AuthorizationHandlerContext context,
        IAuthorizationRequirement requirement, Func<bool> expression)
    {
        if (expression.Invoke())
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}