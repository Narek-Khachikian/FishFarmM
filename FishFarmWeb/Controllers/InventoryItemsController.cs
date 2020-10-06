using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarm.Models;
using FishFarm.Services;
using FishFarmWeb.SharedResources;
using FishFarmWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace FishFarmWeb.Controllers
{
    public class InventoryItemsController : Controller
    {

        private readonly IFishFarmRepository _repository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;


        public InventoryItemsController(IFishFarmRepository repo, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _repository = repo;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<IActionResult> Index(SelectionOptions inStock = SelectionOptions.Active
            , SelectionOptions isFeed = SelectionOptions.All
            ,int page = 1
            ,int perPage = Constants.ItemsPerPage)
        {
            int items = await _repository.GetInventoryItemsCountAsync(inStock, isFeed);
            if(perPage < 2) { perPage = Constants.ItemsPerPage; }
            int pages = (items-1 / perPage);
            if(page < 1) { page = 1; }
            if(page > pages) { page = pages; }
            InventoryItemsIndexViewModel model = new InventoryItemsIndexViewModel()
            {
                Page = page,
                Pages = pages,
                PerPage = perPage,
                InStock = inStock,
                IsFeed = isFeed,
                InventoryItems = await _repository.GetInventoryItemsAsync(inStock, isFeed, page, perPage)
            };
            ViewBag.Title = _stringLocalizer["Inventory Items"].ToString();
            return View(model);
        }


        public async Task<IActionResult> CreateInventoryItem()
        {
            InventoryItemsCreatViewModel model = new InventoryItemsCreatViewModel()
            {
                MeasurmentUnits = await _repository.GetAllMeasurmentUnitsAsync(),
                Suppliers = await _repository.GetSuppliersAsync(SelectionOptions.Active,SelectionOptions.All)
            };
            ViewBag.Title = _stringLocalizer["Create Inventory Item"].ToString();
            return View(model);
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateInventoryItem(InventoryItemsCreatViewModel model)
        {
            if (ModelState.IsValid)
            {
                if( await _repository.InventoryItemExistsAsync(model.InventoryItem.Name))
                {
                    ModelState.AddModelError("Item Exists", _stringLocalizer["An item with that name exists in Inventory"].ToString());
                }
                else
                {
                    model.InventoryItem.LastModifiedByName = User.Identity.Name;
                    int result = await _repository.AddInventoryItemAsync(model.InventoryItem);
                    if(result < 1)
                    {
                        TempData["InventoryItemsMessage"] = _stringLocalizer["Nothing added"].ToString();
                    }
                    else
                    {
                        TempData["InventoryItemsMessage"] = _stringLocalizer["New item added to Inventory"].ToString();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            model.MeasurmentUnits = await _repository.GetAllMeasurmentUnitsAsync();
            model.Suppliers = await _repository.GetSuppliersAsync(SelectionOptions.Active, SelectionOptions.All);
            ViewBag.Title = _stringLocalizer["Create Inventory Item"].ToString();
            return View(model);
        }
    }
}
