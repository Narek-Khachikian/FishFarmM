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


        public async Task<IActionResult> Index(SelectionOptions status = SelectionOptions.All
            , SelectionOptions batch = SelectionOptions.All
            , int page = 1
            , int perPage = Constants.ItemsPerPage)
        {
            int items = await _repository.GetSuppliersCountAsync(status, batch);
            if (perPage < 2) { perPage = Constants.ItemsPerPage; }
            int pages = ((items + perPage - 1)  / perPage);
            if(page < 1) { page = 1; }
            if(page > pages) { page = pages; }
            SupplierIndexViewModel model = new SupplierIndexViewModel()
            {
                Suppliers = await _repository.GetSuppliersAsync(status, batch, page, perPage),
                Page = page,
                Pages = pages,
                perPage = perPage,
                Status = status,
                Batch = batch
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


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditSupplier(SupplierEditViewModel model)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                model.Supplier.LastModifiedByName = User.Identity.Name;
                result = await _repository.UpdateSupplierAsync(model.Supplier);
                if (result < 1)
                {
                    TempData["SupplierMessage"] = _stringLocalizer["Nothing changed"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["SupplierMessage"] = _stringLocalizer["Supplier modified successfully"].ToString();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                model.Supplier.Contacts = (await _repository.GetSupplierByIdAsync(model.Supplier.Id)).Contacts;
                ViewBag.Title = _stringLocalizer["Edit Supplier"].ToString();
                return View(model);
            }
        }



        public async Task<IActionResult> DetailSupplier(long id)
        {
            Supplier sup = await _repository.GetSupplierByIdAsync(id);
            if(sup != null)
            {
                SupplierEditViewModel model = new SupplierEditViewModel()
                {
                    Supplier = sup
                };
                ViewBag.Title = _stringLocalizer["Detailes Supplier"].ToString();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
