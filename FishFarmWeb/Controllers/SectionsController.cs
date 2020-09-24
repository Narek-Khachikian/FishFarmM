using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class SectionsController : Controller
    {
        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public SectionsController(IFishFarmRepository repo, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repo;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<IActionResult> Index()
        {
            SectionIndexViewModel model = new SectionIndexViewModel()
            {
                Sections = await _repository.GetSectionsAsync()
            };
            return View(model);
        }


        public IActionResult CreateSection()
        {
            return View();
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSection(Section model)
        {
            if (ModelState.IsValid)
            {
                if (await _repository.SectionExistsAsync(model.Name))
                {
                    ModelState.AddModelError("Section Exists", _stringLocalizer["A section with that name already exists"]);
                }
                else
                {
                    model.CreationDate = DateTime.Now;
                    model.LastModificationDate = model.CreationDate;
                    model.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddSectionAsync(model);
                    if (result < 1)
                    {
                        TempData["SectionMessage"] = _stringLocalizer["Failed to create"].ToString();
                    }
                    TempData["SectionMessage"] = _stringLocalizer["Section created successfully"].ToString();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}
