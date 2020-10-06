using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class InventoryItem : BaseModel
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public bool IsFeed { get; set; }


        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public long MeasurmentUnitId { get; set; }
        public MeasurmentUnit MeasurmentUnit { get; set; }

        public IEnumerable<InventoryIn> InventoryIns { get; set; }
    }
}
