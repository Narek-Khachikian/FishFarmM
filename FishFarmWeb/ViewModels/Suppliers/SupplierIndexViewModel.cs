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
    }
}
