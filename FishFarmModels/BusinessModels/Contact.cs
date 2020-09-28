using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FishFarm.Models
{
    public class Contact : BaseModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public bool IsLegalEntity { get; set; }


        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
