using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CIS174_TestCoreApp.Controllers
{
    public class HouseController : Controller
    {
        IEnumerable<HouseViewModel> Houses = new List<HouseViewModel> {

            new HouseViewModel{id = 1,  Bedrooms = 4, SquareFeet= 1854, DateBuilt=  "05/28/1973", Flooring = "Carpet"},
            new HouseViewModel{id = 2, Bedrooms = 3, SquareFeet= 1675, DateBuilt = "10/17/2015", Flooring = "Hardwood"},
        };

        //need output in json
        [HttpGet("api/house")]
        public JsonResult Index()
        {
            return Json(Houses);
        }

        //need to output in xml

        [HttpGet("api/house/{id}")]
        [Produces("application/xml")]
        public IActionResult Index(int id)
        {
            if (id > 0 && id <= Houses.Count())
            {
                if (id == Houses.ElementAt(id - 1).id)
                {
                    return Ok(Houses.ElementAt(id - 1));
                }
            }
            return NotFound();
            
        }

        [HttpPost("api/house/create")]
        [Produces("application/xml")]
        public IActionResult CreateHouseObject([FromBody]HouseViewModel house)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 201;
                return View(house);
            }
            return NotFound();
        }
    }
}