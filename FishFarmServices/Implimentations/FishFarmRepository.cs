using FishFarm.Data;
using FishFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFarm.Services
{
    internal class FishFarmRepository : IFishFarmRepository
    {
        private readonly FishFarmDataContext _dbContext;

        public FishFarmRepository(FishFarmDataContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Sections


        public async Task<int> AddSectionAsync(Section model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.LastModificationDate = model.CreationDate;
            _dbContext.Sections.Add(model);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SectionExistsAsync(string name)
        {
            bool result = false;
            if(await _dbContext.Sections.Where(s=>s.Name.ToUpper() == name.ToUpper()).AnyAsync())
            {
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<Section>> GetSectionsAsync()
        {
            IEnumerable<Section> result = await _dbContext.Sections.ToListAsync();
            return result;
        }

        public async Task<Section> GetSectionByIdAsync(long id)
        {
            Section result = await _dbContext.Sections.FindAsync(id);
            return result;
        }


        /// <summary>
        /// Updates the section entity if modified.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returnes -5 if nothing changed, otherwise returns savechangeasync value</returns>
        public async Task<int> UpdateSectionAsync(Section model)
        {
            Section tempData = await GetSectionByIdAsync(model.Id);
            if(tempData.Name != model.Name)
            {
                tempData.Name = model.Name;
                tempData.LastModificationDate = DateTime.UtcNow;
                _dbContext.Sections.Update(tempData);
                return await _dbContext.SaveChangesAsync();
            }
            return -5;
        }


        /// <summary>
        /// Deletes the section entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returnes -5 id not found to delete, otherwise returnes savechangeasync value</returns>
        public async Task<int> DeleteSectionAsync(long id)
        {
            Section tempModel = await _dbContext.Sections.FindAsync(id);
            if(tempModel != null)
            {
                _dbContext.Remove<Section>(tempModel);
                return await _dbContext.SaveChangesAsync();
            }
            return -5;
        }


        #endregion


        #region Tanks

        public async Task<IEnumerable<Tank>> GetAllTanksAsync()
        {
            IEnumerable<Tank> result = await _dbContext.Tanks.Include(t=>t.Section).OrderBy(t=>t.Section.Name).ToListAsync();
            return result;
        }



        #endregion

    }
}
