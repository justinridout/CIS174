using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id)
        {
            //setting the id route parameter to the viewbag so i can use in view 
            ViewBag.id = id;
            //returns the basic student index view due to the route specified in startup.cs
            return View();
        }
    }
}