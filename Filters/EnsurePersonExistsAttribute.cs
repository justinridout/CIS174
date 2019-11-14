using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class EnsurePersonExistsFilter : IActionFilter
    {
        private readonly FamousPersonService _famousPersonService;

        public EnsurePersonExistsFilter(FamousPersonService famousPersonService)
        {
            _famousPersonService = famousPersonService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Not Being Used
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["id"];
            var firstName = _famousPersonService.GetPersonFirstName(id);
            if (!_famousPersonService.DoesPersonExist(id))
            {
                context.Result = new NotFoundResult();
            }
            
            //NEED TO CHECK FIRST NAME
        }
    }

    public class EnsurePersonExistsAttribute : TypeFilterAttribute
    {
        public EnsurePersonExistsAttribute() : base(typeof(EnsurePersonExistsFilter))
        {}
    }
}
