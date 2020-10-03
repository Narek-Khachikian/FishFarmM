using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.SharedResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class MeasurmentUnitsController : Controller
    {

        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public MeasurmentUnitsController(IFishFarmRepository repo, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repo;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<MeasurmentUnit> model = await _repository.GetAllMeasurmentUnitsAsync();

            ViewBag.Title = _stringLocalizer["Measurment Units"].ToString();
            return View(model);
        }


        public IActionResult CreateMeasurmentUnit()
        {
            ViewBag.Title = _stringLocalizer["Create Measurment Unit"].ToString();
            return View();
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateMeasurmentUnit(MeasurmentUnit model)
        {
            if (ModelState.IsValid)
            {
                if (await _repository.MeasurmentUnitExistsAsync(model.Name))
                {
                    ModelState.AddModelError("UnitExists", _stringLocalizer["A measuring unit with that name exists"].ToString());
                    
                }
                else
                {
                    model.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddMeasurmentUnitAsync(model);
                    if(result < 1)
                    {
                        TempData["MeasurmentUnitMessage"] = _stringLocalizer["Nothing added"].ToString();
                    }
                    else
                    {
                        TempData["MeasurmentUnitMessage"] = _stringLocalizer["Measuring unit added successfully"].ToString();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Title = _stringLocalizer["Create Measurment Unit"].ToString();
            return View(model);
        }



        public async Task<IActionResult> ChangeStatus(long id)
        {
            MeasurmentUnit model = await _repository.GetMeasurmentUnitAsync(id);
            if(model != null)
            {
                model.LastModifiedByName = User.Identity.Name;
                int result = await _repository.UpdateMeasurmentUnitAsync(model,true);
                if(result > 0)
                {
                    TempData["MeasurmentUnitMessage"] = _stringLocalizer["Measurment unit changed"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                else if(result == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["MeasurmentUnitMessage"] = _stringLocalizer["Missing measurment unit"].ToString();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteMeasurmentUnit(long id)
        {
            MeasurmentUnit model = await _repository.GetMeasurmentUnitAsync(id);
            if(model != null)
            {
                ViewBag.Title = _stringLocalizer["Delete Measurment unit"].ToString();
                return View(model);
            }
            TempData["MeasurmentUnitMessage"] = _stringLocalizer["Missing measurment unit"].ToString();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteMeasurmentUnitConfirmed([FromForm] long Id)
        {
            if (ModelState.IsValid)
            {
                int result = await _repository.RemoveMeasurmentUnitAsync(Id);
                if(result < 1)
                {
                    TempData["MeasurmentUnitMessage"] = _stringLocalizer["Missing measurment unit"].ToString();
                }
                else
                {
                    TempData["MeasurmentUnitMessage"] = _stringLocalizer["Measurment unit deleted successfully"].ToString();
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
