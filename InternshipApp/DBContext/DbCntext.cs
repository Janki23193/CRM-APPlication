using InternshipApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.DBContext
{
    public class DbCntext : DbContext
    { 
        public DbCntext(DbContextOptions<DbCntext> options): 
            base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
