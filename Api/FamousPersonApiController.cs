using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models.FamousPerson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public FamousPersonApiController(FamousPersonService famousPersonService)
        {
            _famousPersonService = famousPersonService;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var detailed = _famousPersonService.GetFamousPersonDetail(id);
            return Ok(detailed);
        }

        [EnsurePersonExists]
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFamousPersonCommand command)
        {
            _famousPersonService.UpdatePerson(id, command);
            return Ok();

        }
    }
}