using InternshipApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStoreAsync();
        Task<bool> CreateStoreAsync(Store store);
        Task<Store> GetAsync(int? id);
        Task<bool> UpdateStoreAsync(int? id, Store store);
        Task<bool> DeleteStoreAsync(int? id);
    }
}
