using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.ViewModels
{
    public class TankIndexViewModel
    {
        public IEnumerable<Tank> Tanks { get; set; }
    }
}
