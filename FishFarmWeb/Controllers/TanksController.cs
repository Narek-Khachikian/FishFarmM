using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmWeb.SharedResources;

namespace FishFarmWeb.Controllers
{
    public class TanksController : Controller
    {
        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public TanksController(IFishFarmRepository repository, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repository;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Tank> tanks = await _repository.GetAllTanksAsync();
            TankIndexViewModel model = new TankIndexViewModel()
            {
                Tanks = tanks
            };
            ViewBag.Title = _stringLocalizer["Tanks"].ToString();
            return View(model);
        }


        public async Task<IActionResult> CreateTank()
        {
            TankCreateViewModel model = new TankCreateViewModel()
            {
                Sections = await _repository.GetSectionsAsync()
            };
            ViewBag.Title = _stringLocalizer["Create Tank"].ToString();
            return View(model);
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateTank(TankCreateViewModel model)
        {
            if (ModelState.IsValid && model.Tank != null)
            {
                if(await _repository.TankNameExistsAsync(model.Tank.Name))
                {
                    ModelState.AddModelError("Name exists", _stringLocalizer["A tank with that name already exists"]);
                }
                else
                {
                    Tank tankModel = model.Tank;
                    tankModel.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddTankAsync(tankModel);
                    if (result < 1)
                    {
                        TempData["TankMessage"] = _stringLocalizer["Failed to create"].ToString();
                    }
                    else
                    {
                        TempData["TankMessage"] = _stringLocalizer["Tank created successfully"].ToString();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            model.Sections = await _repository.GetSectionsAsync();
            ViewBag.Title = _stringLocalizer["Create Tank"].ToString();
            return View(model);
        }
    }
}
