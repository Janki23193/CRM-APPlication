using InternshipApp.Models;
using InternshipApp.DBContext;
using InternshipApp.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InternshipApp.Repos.Classes
{
    public class ProductRepository : IProductRepository
    {
        protected readonly DbCntext _dbcontext;

        public ProductRepository(DbCntext db)
        {
            _dbcontext = db;        
        }
      
        public async Task<bool> CreateAsync(Product product)
        {
            await _dbcontext.AddAsync(product);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var product = await _dbcontext.Products.ToListAsync();
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<Product> GetAsync(int? id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public async Task<bool> UpdateAsync(int? id, Product product)
        {
            var data = await _dbcontext.Products.FindAsync(id);

            if (data != null)
            {
                _dbcontext.Products.Attach(data);
                data.Name = product.Name;
                data.Price = product.Price;
                await _dbcontext.SaveChangesAsync();

                return true;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(int? id)
        {
            var data = await _dbcontext.Products.Include(S => S.sales).FirstOrDefaultAsync(S=> S.ProductId == id);
            if(data!= null)
            {
                _dbcontext.Products.Remove(data);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

       
    }
}
