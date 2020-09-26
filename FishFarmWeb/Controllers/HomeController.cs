using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarmWeb.SharedResources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using FishFarm.Services;

namespace FishFarmWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly SupportedCultures _cultures;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public HomeController(SupportedCultures cults, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _cultures = cults;
            _stringLocalizer = stringLocalizer;
        }

        
        public IActionResult Index()
        {
            ViewBag.Title =_stringLocalizer["Home"].ToString();
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
