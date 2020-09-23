using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmWeb.SharedResources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace FishFarmWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly SupportedCultures _cultures;

        public HomeController(SupportedCultures cults)
        {
            _cultures = cults;
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }


        public IActionResult SelectLanguage(string cur, string cult)
        {
            if (_cultures.SupportedCulture.Keys.Contains(cult))
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cult)),
                    new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddMonths(6) });
            }
            return LocalRedirect(cur);
        }

    }
}
