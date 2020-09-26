using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Services
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

    public static class FishFarmSupportedCulturesExtention
    {
        public static IServiceCollection SupportedCultures(this IServiceCollection app)
        {
            app.AddSingleton<SupportedCultures>();
            return app;
        }
    }
}
