using CRUDOperations_WebAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperations_WebAPI.Data
{
    public class ContextClass:DbContext
    {
        public ContextClass(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
