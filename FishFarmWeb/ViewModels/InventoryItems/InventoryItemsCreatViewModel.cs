using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.ViewModels
{
    public class InventoryItemsCreatViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public IEnumerable<MeasurmentUnit> MeasurmentUnits { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
