using FishFarmWeb.SharedResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public AdministrationController(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            ViewBag.Title = _stringLocalizer["Administration"].ToString();
            return View();
        }
    }
}
