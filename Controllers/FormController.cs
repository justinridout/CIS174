using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new CreatePersonPlusViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonPlusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Views/Form/Index.cshtml");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}