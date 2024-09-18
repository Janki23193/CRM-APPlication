using InternshipApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): 
            base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
