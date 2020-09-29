using System;
using System.Collections.Generic;
using System.Text;
using FishFarm.Models;
using System.Threading.Tasks;

namespace FishFarm.Services
{
    public interface IFishFarmRepository
    {

        #region Sections
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

        #endregion


        #region Tanks


        Task<IEnumerable<Tank>> GetAllTanksAsync();

        Task<bool> TankNameExistsAsync(string name);

        Task<int> AddTankAsync(Tank model);

        Task<Tank> GetTankByIdAsync(long id);


        /// <summary>
        /// Updates the Tank entity if modified
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Return -5 if nothing changed, otherwise returns savechange result</returns>
        Task<int> UpdateTankAsync(Tank model);


        /// <summary>
        /// Deletes the Tank entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns -5 if tank not found, otherwise returns savechange result</returns>
        Task<int> DeleteTankAsync(long id);

        #endregion



        #region Supplier


        Task<IEnumerable<Supplier>> GetSuppliersAsync();

        Task<int> AddSupplierAsync(Supplier model);

        Task<bool> SupplierWithTINExistsAsync(Supplier model);


        #endregion
    }
}
