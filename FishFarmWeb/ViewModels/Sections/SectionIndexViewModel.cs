using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.ViewModels
{
    public class SectionIndexViewModel
    {
        public IEnumerable<Section> Sections { get; set; }
    }
}
