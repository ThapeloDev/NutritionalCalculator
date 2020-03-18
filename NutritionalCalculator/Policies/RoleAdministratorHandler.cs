using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Policies
{
    public class RoleAdministratorHandler : AuthorizationHandler<RoleAdministratorHandler>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAdministratorHandler requirement)
        {
            AreParametersNull(context, requirement);
            if (context.User.HasClaim("Administrator", "Administrator"))
            {
                context.Succeed(requirement);
            }else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }

        private void AreParametersNull(AuthorizationHandlerContext context, RoleAdministratorHandler requirement)
        {
            if (context == null || requirement == null) throw new ArgumentNullException(nameof(context));
        }
    }
}
