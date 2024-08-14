using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int? id);
        Task<bool> UpdateAsync(int? id, Product product);
        Task<bool> DeleteAsync(int? id);
       


    }
}
