using FishFarm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FishFarm.Models
{
    public class Section : BaseModel
    {
        [Required]
        public string Name { get; set; }


        public IEnumerable<Tank> Tanks { get; set; }
    }
}
