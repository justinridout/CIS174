using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class EnsurePersonExistsFilter : IActionFilter
    {
        private readonly FamousPersonService _famousPersonService;
        private readonly ILogger _log;

        public EnsurePersonExistsFilter(FamousPersonService famousPersonService,
            ILogger<EnsurePersonExistsAttribute> log)
        {
            _log = log;
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
                _log.LogWarning(
                    "Person {personId} does not exist", id);

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
