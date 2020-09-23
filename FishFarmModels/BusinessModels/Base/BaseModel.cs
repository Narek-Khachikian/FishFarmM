using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string LastModifiedByName { get; set; }
    }
}
