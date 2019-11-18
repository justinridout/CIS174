using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models.FamousPerson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


//Assignment 11.1
namespace CIS174_TestCoreApp.Api
{
    [ValidateModel]
    [ExceptionHandler]
    [FeatureEnabled(IsEnabled = true)]
    [Route("api/famousperson")]
    [ApiController]
    public class FamousPersonApiController : ControllerBase
    {
        public FamousPersonService _famousPersonService;
        private readonly ILogger _log;
        public FamousPersonApiController(FamousPersonService famousPersonService,
            ILogger<FamousPersonApiController> log)
        {
            _log = log;
            _famousPersonService = famousPersonService;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _log.LogInformation(
                "Loading Person with id {PersonId}", id);
            var detailed = _famousPersonService.GetFamousPersonDetail(id);
            return Ok(detailed);
        }

        [EnsurePersonExists]
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFamousPersonCommand command)
        {
            _log.LogInformation(
                "Updating person with id {PersonId}", id);
            _famousPersonService.UpdatePerson(id, command);
            return Ok();

        }
    }
}