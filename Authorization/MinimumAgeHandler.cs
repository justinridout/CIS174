﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Authorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>

    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)

        {
            var dateOfBirthClaim = context.User.FindFirstValue(ClaimTypes.DateOfBirth);

            if (dateOfBirthClaim == null)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim);
            var cutoff = dateOfBirth.AddYears(requirement.MinimumAge);

            if (cutoff < DateTime.Today)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
