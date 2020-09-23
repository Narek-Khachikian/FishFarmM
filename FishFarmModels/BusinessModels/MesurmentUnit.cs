using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class MesurmentUnit : BaseModel
    {
        public string Name { get; set; }


        
        public IEnumerable<InventoryItem> InventoryItems { get; set; }
    }
}
