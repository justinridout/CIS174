using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models.FamousPerson;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class FamousPeopleController : Controller
    {
        public FamousPersonService _service;
        public FamousPeopleController(FamousPersonService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var models = _service.GetFamousPerson();
            return View(models);
        }

        public IActionResult View(int id)
        {
            var model = _service.GetFamousPersonDetail(id);
            if (model == null) //checks if id is hooked to valid person. else returns not found
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreateFamousPersonCommand());
        }

        [HttpPost]
        public IActionResult Create(CreateFamousPersonCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _service.CreateFamousPerson(command);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
            }
            return View(command);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetPersonForUpdate(id);
            if (model == null)
            {
                //Checks if id is hooked to valid person
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateFamousPersonCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdateFamousPerson(command);
                    return RedirectToAction(nameof(View), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
            }
            return View(command);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _service.DeleteFamousPerson(id);

            return RedirectToAction(nameof(Index));
        }
    }
}