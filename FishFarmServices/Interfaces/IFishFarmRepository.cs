using System;
using System.Collections.Generic;
using System.Text;
using FishFarm.Models;
using System.Threading.Tasks;

namespace FishFarm.Services
{
    public interface IFishFarmRepository
    {
        Task<bool> SectionExistsAsync(string name);
        Task<int> AddSectionAsync(Section model);
        Task<IEnumerable<Section>> GetSectionsAsync();


    }
}
