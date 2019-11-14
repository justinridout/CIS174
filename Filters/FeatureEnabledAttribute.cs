using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    //NEED TO ADD STUFF HERE STILL
    public class FeatureEnabledAttribute : Attribute, IResourceFilter
    {
        public bool IsEnabled { get; set; }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // nothing to do here
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!IsEnabled) {
                context.Result = new BadRequestResult();
            }

            context.HttpContext.Items["Guid"] = Guid.NewGuid().ToString();
        }
    }
}
