using FishFarm.Models;
using FishFarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class SettingsController : Controller
    {

        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public SettingsController(IFishFarmRepository repo, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repo;
            _stringLocalizer = stringLocalizer;

        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult CreateSection()
        {
            return View();
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSection(Section model)
        {
            if (ModelState.IsValid)
            {
                if(await _repository.SectionExistsAsync(model.Name))
                {
                    ModelState.AddModelError("Section Exists", _stringLocalizer["A section with that name already exists"]);
                    return View(model);
                }

                model.CreationDate = DateTime.Now;
                model.LastModificationDate = model.CreationDate;
                model.LastModifiedByName = User.Identity.Name;
                int result = await _repository.AddSectionAsync(model);
                if(result < 1)
                {
                    TempData["Message"] = _stringLocalizer["Failed to create"];
                }
                TempData["Message"] = _stringLocalizer["Section created successfully"];
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
