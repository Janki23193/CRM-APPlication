using InternshipApp.DBContext;
using InternshipApp.Models;
using InternshipApp.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Classes
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DbCntext _db;
        public StoreRepository(DbCntext db)
        {
            _db = db;
        }
        public async Task<bool> CreateStoreAsync(Store store)
        {
            await _db.Stores.AddAsync(store);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStoreAsync(int? id)
        {
            var data = await _db.Stores.Include(val => val.sales).FirstOrDefaultAsync(s => s.StoreId == id);
            if (data != null)
            {
                 _db.Stores.Remove(data);
                 await _db.SaveChangesAsync();
                 return true;
            }
            return false;
        }

        public async Task<IEnumerable<Store>> GetAllStoreAsync()
        {
            var data = await _db.Stores.ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Store> GetAsync(int? id)
        {
            var data = await _db.Stores.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<bool> UpdateStoreAsync(int? id, Store store)
        {
            var data = await _db.Stores.FindAsync(id);
            if (data != null)
            {
                 _db.Stores.Attach(data);
                data.Name = store.Name;
                data.Address = store.Address;
                data.sales = store.sales;
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }
    }
}
