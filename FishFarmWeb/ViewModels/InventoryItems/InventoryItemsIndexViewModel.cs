using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.ViewModels
{
    public class InventoryItemsIndexViewModel
    {
        public IEnumerable<InventoryItem> InventoryItems { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public SelectionOptions IsFeed { get; set; }
        public SelectionOptions InStock { get; set; }
    }
}
