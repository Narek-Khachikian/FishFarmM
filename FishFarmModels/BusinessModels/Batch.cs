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
        public string Country { get; set; }


        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public IEnumerable<InOut> InOuts { get; set; }

    }
}
