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
            await _dbContext.Sections.AddAsync(model);
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

        public async Task<bool> TankNameExistsAsync(string name)
        {
            bool result = await _dbContext.Tanks.Where(t => t.Name.ToUpper() == name.ToUpper()).AnyAsync();
            return result;
        }

        public async Task<int> AddTankAsync(Tank model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.LastModificationDate = model.CreationDate;
            await _dbContext.Tanks.AddAsync(model);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Tank> GetTankByIdAsync(long id)
        {
            Tank tank = await _dbContext.Tanks.FindAsync(id);
            return tank;
        }


        /// <summary>
        /// Updates the Tank entity if modified
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Return -5 if nothing changed, otherwise returns savechange result</returns>
        public async Task<int> UpdateTankAsync(Tank model)
        {
            if(model != null)
            {
                Tank tempModel = await GetTankByIdAsync(model.Id);
                if (tempModel == null)
                {
                    return -5;
                }
                if (tempModel.Depth != model.Depth
                    || tempModel.Lenght != model.Lenght
                    || tempModel.Name != model.Name
                    || tempModel.SectionId != model.SectionId
                    || tempModel.Shape != model.Shape
                    || tempModel.SurfaceArea != model.SurfaceArea
                    || tempModel.Volume != model.Volume
                    || tempModel.Width != model.Width)
                {
                    tempModel.Depth = model.Depth;
                    tempModel.Lenght = model.Lenght;
                    tempModel.Name = model.Name;
                    tempModel.SectionId = model.SectionId;
                    tempModel.Shape = model.Shape;
                    tempModel.SurfaceArea = model.SurfaceArea;
                    tempModel.Volume = model.Volume;
                    tempModel.Width = model.Width;
                    tempModel.LastModificationDate = DateTime.UtcNow;
                    _dbContext.Tanks.Update(tempModel);
                    int result = await _dbContext.SaveChangesAsync();
                    return result;
                }
            }
            return -5;
        }


        /// <summary>
        /// Deletes the Tank entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns -5 if tank not found, otherwise returns savechange result</returns>
        public async Task<int> DeleteTankAsync(long id)
        {
            Tank model = await GetTankByIdAsync(id);
            int result = -5;
            if(model != null)
            {
                _dbContext.Tanks.Remove(model);
                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }

        #endregion


        #region Suppliers


        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _dbContext.Suppliers.OrderBy(s=>s.Name).ToListAsync();
        }


        public async Task<int> AddSupplierAsync(Supplier model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.LastModificationDate = model.CreationDate;
            _dbContext.Suppliers.Add(model);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<bool> SupplierWithTINExistsAsync(Supplier model)
        {
            if(model.TINCode == string.Empty)
            {
                return false;
            }
            return await _dbContext.Suppliers.Where(s => s.TINCode == model.TINCode).AnyAsync();
        }


        public async Task<Supplier> GetSupplierByIdAsync(long id)
        {
            Supplier result = await _dbContext.Suppliers.Where(s=>s.Id == id)?.Include(s=>s.Contacts).FirstOrDefaultAsync();
            return result;
        }


        /// <summary>
        /// Updates the supplier entity, without modifing
        /// </summary>
        /// <param name="model"></param>
        /// <returns>returns -5 if nothing changed, otherwise returnes SaveChange result</returns>
        public async Task<int> UpdateSupplierAsync(Supplier model)
        {
            Supplier tempModel = await GetSupplierByIdAsync(model.Id);
            int result = 0;
            if (tempModel != null)
            {
                if (model.IsBatchSupplier != tempModel.IsBatchSupplier
                    || model.Name != tempModel.Name
                    || model.Status != tempModel.Status
                    || model.TINCode != tempModel.TINCode)
                {
                    tempModel.IsBatchSupplier = model.IsBatchSupplier;
                    tempModel.Name = model.Name;
                    tempModel.Status = model.Status;
                    tempModel.TINCode = model.TINCode;
                    tempModel.LastModificationDate = DateTime.UtcNow;
                    
                    _dbContext.Suppliers.Update(tempModel);
                    result = await _dbContext.SaveChangesAsync();
                }
                else
                {
                    result = -5;
                }
            }
            else
            {
                result = -5;
            }
            return result;
        }


        #endregion



        #region Contacts


        public async Task<int> AddContactAsync(Contact model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.LastModificationDate = model.CreationDate;
            await _dbContext.Contacts.AddAsync(model);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<Contact> GetContactByIdAsync(long id)
        {
            return await _dbContext.Contacts.FindAsync(id);
        }


        public async Task<int> UpdateContactAsync(Contact model)
        {
            int result = 0;
            Contact tempModel = await GetContactByIdAsync(model.Id);
            if ( tempModel != null)
            {
                if (!string.IsNullOrEmpty(model.PhoneNumber) 
                    && string.IsNullOrEmpty(model.Address) 
                    && string.IsNullOrEmpty(model.Email)
                    && string.IsNullOrEmpty(model.MobileNumber))
                {
                    if(model.PhoneNumber != tempModel.PhoneNumber)
                    {
                        tempModel.PhoneNumber = model.PhoneNumber;
                    }
                    else
                    {
                        return result;
                    }
                }
                else if(string.IsNullOrEmpty(model.PhoneNumber) 
                    && !string.IsNullOrEmpty(model.Address) 
                    && string.IsNullOrEmpty(model.Email)
                    && string.IsNullOrEmpty(model.MobileNumber))
                {
                     if (model.Address != tempModel.Address)
                     {
                        tempModel.Address = model.Address;
                     }
                     else
                     {
                        return result;
                     }
                }
                else if (string.IsNullOrEmpty(model.PhoneNumber) 
                    && string.IsNullOrEmpty(model.Address) 
                    && !string.IsNullOrEmpty(model.Email)
                    && string.IsNullOrEmpty(model.MobileNumber))
                {
                     if (model.Email != tempModel.Email)
                     {
                        tempModel.Email = model.Email;
                     }
                     else
                     {
                        return result;
                     }
                }
                else if (string.IsNullOrEmpty(model.PhoneNumber)
                    && string.IsNullOrEmpty(model.Address)
                    && string.IsNullOrEmpty(model.Email)
                    && !string.IsNullOrEmpty(model.MobileNumber))
                {
                     if (model.MobileNumber != tempModel.MobileNumber)
                     {
                        tempModel.MobileNumber = model.MobileNumber;
                     }
                     else
                     {
                        return result;
                     }
                }
                else
                {
                     return result;
                }

                tempModel.LastModificationDate = DateTime.UtcNow;
                _dbContext.Contacts.Update(tempModel);
                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }


        public async Task<int> DeleteContactAsync(Contact model)
        {
            int result = 0;
            Contact tempModel = await GetContactByIdAsync(model.Id);
            if(tempModel != null)
            {
                _dbContext.Contacts.Remove(tempModel);
                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }


        #endregion

    }
}
