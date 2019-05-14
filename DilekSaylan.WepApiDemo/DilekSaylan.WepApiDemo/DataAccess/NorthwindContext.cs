using DilekSaylan.WepApiDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilekSaylan.WepApiDemo.DataAccess
{
    public class NorthwindContext:DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=ASUS-PC\SQLEXPRESS;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
