using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class DailyReport : BaseModel
    {
        public DateTime Date { get; set; }
        public long DeadFish { get; set; }
        public double DeadFishWeight { get; set; }
        public double? AverageWight { get; set; }
        public double FeedAmount { get; set; }


        
        public long InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }



        public long TankId { get; set; }
        public Tank Tank { get; set; }
    }
}
