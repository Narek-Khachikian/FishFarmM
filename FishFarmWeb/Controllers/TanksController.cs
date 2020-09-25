using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
