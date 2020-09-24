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
        Task<Section> GetSectionByIdAsync(long id);

        /// <summary>
        /// Updates the section entity if modified.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returnes -5 if nothing changed, otherwise returns savechangeasync value</returns>
        Task<int> UpdateSectionAsync(Section model);


        /// <summary>
        /// Deletes the section entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returnes -5 id not found to delete, otherwise returnes savechangeasync value</returns>
        Task<int> DeleteSectionAsync(long id);

    }
}
