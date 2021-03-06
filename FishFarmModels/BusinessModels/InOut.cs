﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class InOut : BaseModel
    {
        public DateTime Date { get; set; }
        public InOutType InOutType { get; set; }
        public long Quantity { get; set; } //in whole number
        public double Weight { get; set; } //in kg
        public double AverageWight { get; set; } //in g
        public double AverageLenght { get; set; } //in mm


        public long BatchId { get; set; }
        public Batch Batch { get; set; }


        public In In { get; set; }

        public Out Out { get; set; }
    }
}
