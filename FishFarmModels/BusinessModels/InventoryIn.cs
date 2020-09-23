using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class InventoryIn : BaseModel
    {

        public DateTime Date { get; set; }
        public double InQuantity { get; set; }
        


        public long InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }
    }
}
