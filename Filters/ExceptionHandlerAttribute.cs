using CIS174_TestCoreApp.Models.FamousPerson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        private readonly FamousPersonService _famousPersonService;
        readonly ILogger<ExceptionHandlerAttribute> _logger; 

        public ExceptionHandlerFilter(FamousPersonService famousPersonService,
            ILogger<ExceptionHandlerAttribute> logger)
        {
            _logger = logger;
            _famousPersonService = famousPersonService;
        }

        public override void OnException(ExceptionContext context)
        {
            var error = new
            {
                Success = false,
                Errors = new[]
                {
                    context.Exception.Message
                }
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };

            if (context.HttpContext.Response.StatusCode >= 400 &&
                context.HttpContext.Response.StatusCode < 600)
            {
                CreateErrorLogCommand cmd = new CreateErrorLogCommand
                {
                    httpstatuscode = context.HttpContext.Response.StatusCode,
                    TimeOfError = DateTime.Now,
                    RequestedId = (int)context.HttpContext.Items["Guid"],
                    ExceptionMessage = context.Exception.Message,

                };

                _logger.LogWarning(
                    "Bad Status code of {StatusCode}", context.HttpContext.Response.StatusCode);

                _famousPersonService.CreateErrorLog(cmd);
            }

            context.ExceptionHandled = true;
        }
    }
    public class ExceptionHandlerAttribute : TypeFilterAttribute
    {
        public ExceptionHandlerAttribute() : base(typeof(ExceptionHandlerFilter))
        { }
    }
}
