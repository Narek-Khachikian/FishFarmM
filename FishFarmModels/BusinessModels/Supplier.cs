using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FishFarm.Models
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }

        
        public string TINCode { get; set; }

        public bool IsBatchSupplier { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        
    }
}
