using InternshipApp.DBContext;
using InternshipApp.DTO;
using InternshipApp.Models;
using InternshipApp.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Classes
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public SalesRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateSalesAsync(Sales sale)
        {
            await _dbcontext.Sales.AddAsync(sale);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSalesAsync(int? id)
        {
            var data = await _dbcontext.Sales.FindAsync(id);
            if (data != null)
            {
                _dbcontext.Sales.Remove(data);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<SalesDTO>> GetAllSalesAsync()
        {
            var Sales = await _dbcontext.Sales.ToListAsync();
            var Customer = await _dbcontext.Customers.ToListAsync();
            var Store = await _dbcontext.Stores.ToListAsync();
            var Product = await _dbcontext.Products.ToListAsync();

            var data = from s in Sales
                       join c in Customer
                       on s.CustomerId equals c.CustomerId
                       join p in Product on s.ProductId equals p.ProductId
                       join st in Store on s.StoreId equals st.StoreId
                       select new SalesDTO
                       {
                           SalesId = s.SalesId,
                           CustomerId = s.CustomerId,
                           CustomerName = c.Name,
                           ProductId = s.ProductId,
                           ProductName = p.Name,
                           StoreId = s.StoreId,
                           StoreName = st.Name ,
                           DateSold = s.DateSold
                       };
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<SalesDTO>> GetSalesAsync(int? id)
        {
            var sales = await _dbcontext.Sales.ToListAsync();
            var product = await _dbcontext.Products.ToListAsync();
            var store = await _dbcontext.Stores.ToListAsync();
            var cust = await _dbcontext.Customers.ToListAsync();

            var data = from s in sales.Where(s => s.SalesId == id)
                       join c in cust on s.CustomerId equals c.CustomerId
                       join p in product on s.ProductId equals p.ProductId
                       join st in store on s.StoreId equals st.StoreId
                       select new SalesDTO{
                        SalesId = s.SalesId,
                        CustomerId = s.CustomerId,
                        CustomerName = c.Name,
                        StoreId = s.StoreId,
                        StoreName = st.Name,
                        ProductId = s.ProductId,
                        ProductName = p.Name,
                        DateSold = s.DateSold

            };
            if (data != null)
            {
                return data ;
            }
            return null;
        }
        public async Task<bool> UpdateSalesAsync(int? id, Sales sale)
        {
                var data = await _dbcontext.Sales.FindAsync(id);
                if (data != null)
                {
                  _dbcontext.Sales.Attach(data);
                data.CustomerId = sale.CustomerId;
                data.ProductId = sale.ProductId;
                data.StoreId = sale.StoreId;
                data.DateSold = sale.DateSold;
                await _dbcontext.SaveChangesAsync();
                return true;
                } 
            return false;           
        }
    }
}

