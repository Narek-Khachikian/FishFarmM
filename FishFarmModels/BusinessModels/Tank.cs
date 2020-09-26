using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FishFarm.Models
{
    public class Tank : BaseModel
    {
        [Required]
        [StringLength(64,MinimumLength =3)]
        public string Name { get; set; }
        public double Lenght { get; set; }//in m
        public double Width { get; set; }//in m
        public double Depth { get; set; }//in m
        public double Volume { get; set; }//in m^3
        public double SurfaceArea { get; set; }//in m^2
        public TankShape Shape { get; set; }
        

        public long SectionId { get; set; }
        public Section Section { get; set; }


        public IEnumerable<In> Ins { get; set; }
        public IEnumerable<Out> Outs { get; set; }

    }
}
