using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FishFarm.Models
{
    public class BaseModel
    {
        public long Id { get; set; }

        
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string LastModifiedByName { get; set; }

        [DefaultValue(true)]
        public bool? Status { get; set; }
    }
}
