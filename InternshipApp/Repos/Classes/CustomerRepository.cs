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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbCntext _dbcontext;
        public CustomerRepository(DbCntext db)
        {
            _dbcontext = db;
        }
        public async Task<bool> CreateAsync(Customer customer)
        {
            await _dbcontext.Customers.AddAsync(customer);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customer = await _dbcontext.Customers.ToListAsync();
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _dbcontext.Customers.Include(val => val.sales).FirstOrDefaultAsync(val => val.CustomerId == id);
            if(data!=null)
            {
                _dbcontext.Customers.Remove(data);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Customer> GetAsync(int? id)
        {
            var customer = await _dbcontext.Customers.FindAsync(id);
            if(customer!=null)
            {
                return customer;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int? id, Customer customer)
        {
            var data = await _dbcontext.Customers.FindAsync(id);
            if(data!=null)
            {
                _dbcontext.Customers.Attach(data);
                data.Name = customer.Name;
                data.Address = customer.Address;
                data.sales = customer.sales;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
