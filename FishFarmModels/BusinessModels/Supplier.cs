using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }
        public string TINCode { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        
    }
}
