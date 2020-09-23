using FishFarm.Data;
using FishFarm.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddSectionAsync(Section model)
        {
            _dbContext.Sections.Add(model);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SectionExistsAsync(string name)
        {
            bool result = false;
            if(await _dbContext.Sections.Where(s=>s.Name == name).AnyAsync())
            {
                result = true;
            }
            return result;
        }
    }
}
