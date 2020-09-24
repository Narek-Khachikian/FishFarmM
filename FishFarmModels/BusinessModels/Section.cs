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
        [StringLength(64,MinimumLength =3)]
        public string Name { get; set; }


        public IEnumerable<Tank> Tanks { get; set; }
    }
}
