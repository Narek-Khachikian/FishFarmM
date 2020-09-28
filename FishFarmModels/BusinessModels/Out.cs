using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Models
{
    public class Out : BaseModel
    {
        public bool IsTankEmpty { get; set; }

        public bool IsNull { get; set; }

        public long InOutId { get; set; }
        public InOut InOut { get; set; }

        public long TankId { get; set; }
        public Tank Tank { get; set; }

    }
}
