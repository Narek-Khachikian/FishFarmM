using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.SharedResources;
using FishFarmWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class SuppliersController : Controller
    {

        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public SuppliersController(IFishFarmRepository repo, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repo;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<IActionResult> Index()
        {
            SupplierIndexViewModel model = new SupplierIndexViewModel()
            {
                Suppliers = await _repository.GetSuppliersAsync()
            };
            
            ViewBag.Title = _stringLocalizer["Suppliers"].ToString();
            return View(model);
        }


        public IActionResult CreateSupplier()
        {
            ViewBag.Title = _stringLocalizer["Create Supplier"].ToString();
            return View();
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSupplier(Supplier model)
        {
            if (ModelState.IsValid)
            {
                if (await _repository.SupplierWithTINExistsAsync(model))
                {
                    ModelState.AddModelError("SupplierExistsTIN", _stringLocalizer["A supplier with the same TIN exists"].ToString());
                }
                else
                {
                    model.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddSupplierAsync(model);
                    if (result > 0 )
                    {
                        TempData["SupplierMessage"] = _stringLocalizer["Supplier created successfully"].ToString();
                    }
                    else
                    {
                        TempData["SupplierMessage"] = _stringLocalizer["Failed to create"].ToString();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Title = _stringLocalizer["Create Supplier"].ToString();
            return View(model);
        }



        public async Task<IActionResult> EditSupplier(long id)
        {
            SupplierEditViewModel model = new SupplierEditViewModel()
            {
                Supplier = await _repository.GetSupplierByIdAsync(id)
            };
            if(model != null)
            {
                ViewBag.Title = _stringLocalizer["Edit Supplier"].ToString();
                return View(model);
            }
            TempData["SupplierMessage"] = _stringLocalizer["Selected Supplier was missing"].ToString();
            return RedirectToAction(nameof(Index));
        }


        //[HttpPost,AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> EditSupplier()
        //{

        //}

    }
}
