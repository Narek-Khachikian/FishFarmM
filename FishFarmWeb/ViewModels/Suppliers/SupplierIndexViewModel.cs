using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.ViewModels
{
    public class SupplierIndexViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }

        public int Page { get; set; }
        public int perPage { get; set; }
        public int Pages { get; set; }
        public SelectionOptions Status { get; set; }
        public SelectionOptions Batch { get; set; }
    }
}
