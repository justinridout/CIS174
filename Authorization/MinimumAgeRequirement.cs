﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement

    {

        public MinimumAgeRequirement(int minimumAge)

        {

            MinimumAge = minimumAge;

        }

        public int MinimumAge { get; }

    }
}
