using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class Batch : BaseModel
    {
        public string Name { get; set; }
        public string FishType { get; set; }
        public long Quantity { get; set; } //in whole numbers
        public double Weight { get; set; } //in kg
        public double AverageWeight { get; set; } //in g
        public double AverageLenght { get; set; } //in mm
        public long AlocatedQuantity { get; set; } //in whole number, in the end should be equal to the Quantity


        public long BatchSupplierId { get; set; }
        public BatchSupplier BatchSupplier { get; set; }

    }
}
