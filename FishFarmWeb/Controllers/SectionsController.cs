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
using FishFarmWeb.SharedResources;

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
            ViewBag.Title = _stringLocalizer["Sections"].ToString();
            return View(model);
        }


        public IActionResult CreateSection()
        {
            ViewBag.Title = _stringLocalizer["Create Section"].ToString();
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
                    model.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddSectionAsync(model);
                    if (result < 1)
                    {
                        TempData["SectionMessage"] = _stringLocalizer["Failed to create"].ToString();
                    }
                    else
                    {
                        TempData["SectionMessage"] = _stringLocalizer["Section created successfully"].ToString();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Title = _stringLocalizer["Create Section"].ToString();
            return View(model);
        }


        public async Task<IActionResult> EditSection(long id)
        {
            Section model = await _repository.GetSectionByIdAsync(id);
            if(model != null)
            {
                ViewBag.Title = _stringLocalizer["Edit Section"].ToString();
                return View(model);
            }
            TempData["SectionMessage"] = _stringLocalizer["Selected section was missing"].ToString();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditSection(Section model)
        {
            if (ModelState.IsValid)
            {
                model.LastModifiedByName = User.Identity.Name;
                int result = await _repository.UpdateSectionAsync(model);
                if(result == -5)
                {
                    TempData["SectionMessage"] = _stringLocalizer["Nothing changed"].ToString();
                    
                }
                else if(result == 1)
                {
                    TempData["SectionMessage"] = _stringLocalizer["Section modified successfully"].ToString();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Title = _stringLocalizer["Edit Section"].ToString();
            return View(model);
        }


        public async Task<IActionResult> DeleteSection(long id)
        {
            Section model = await _repository.GetSectionByIdAsync(id);
            if (model != null)
            {
                ViewBag.Title = _stringLocalizer["Delete Section"].ToString();
                return View(model);
            }
            TempData["SectionMessage"] = _stringLocalizer["Selected section is missing"].ToString();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteSection([FromForm] long id, bool a = true)
        {
            if (ModelState.IsValid)
            {
                int result = await _repository.DeleteSectionAsync(id);
                if(result == -5)
                {
                    TempData["SectionMessage"] = _stringLocalizer["Nothing deleted"].ToString();
                    
                }
                else if(result == 1)
                {
                    TempData["SectionMessage"] = _stringLocalizer["Section Deleted successfully"].ToString();
                }
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DetailSection(long id, long dd = 0)
        {
            Section model = await _repository.GetSectionByIdAsync(id);
            if(model != null)
            {
                ViewBag.Title = _stringLocalizer["Details"].ToString();
                return View(model);
            }
            TempData["SectionMessage"] = _stringLocalizer["Selected section is missing"].ToString();
            return RedirectToAction(nameof(Index));
        }
    }
}
