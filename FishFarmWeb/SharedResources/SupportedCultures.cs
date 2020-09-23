using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.SharedResources
{
    public class SupportedCultures
    {
        public Dictionary<string, string> SupportedCulture { get; } = new Dictionary<string, string>();
        public SupportedCultures()
        {
            SupportedCulture.Add("en", "Eng");
            SupportedCulture.Add("hy", "Հայ");
        }
    }
}
