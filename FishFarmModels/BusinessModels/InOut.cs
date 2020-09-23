using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class InOut : BaseModel
    {
        public DateTime Date { get; set; }
        public InOutType InOutType { get; set; }
        public long BatchId { get; set; }
        public long Quantity { get; set; } //in whole number
        public double Weight { get; set; } //in kg
        public double AverageWight { get; set; } //in g
        public double AverageLenght { get; set; } //in mm



        public long? InId { get; set; }
        public long? OutId { get; set; }
    }
}
