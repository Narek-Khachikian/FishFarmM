using FishFarm.Models;
using FishFarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmWeb.SharedResources;

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
            ViewBag.Title = _stringLocalizer["Settings"].ToString();
            return View();
        }
    }
}
