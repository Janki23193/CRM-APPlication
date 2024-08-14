using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CreateAsync(Customer customer);
        Task<Customer> GetAsync(int? id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<bool> UpdateAsync(int? id, Customer customer);
        Task<bool> DeleteAsync(int id);
    }
}
