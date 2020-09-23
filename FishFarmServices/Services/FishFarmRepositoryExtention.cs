using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishFarm.Services
{
    public static class FishFarmRepositoryExtention
    {
        public static IServiceCollection FishFarmRepository(this IServiceCollection serivces)
        {
            serivces.AddScoped<IFishFarmRepository, FishFarmRepository>();
            return serivces;
        }
    }
}
