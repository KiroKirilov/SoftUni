using Company.Data.Config;
using Company.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
        {    
        }

        public CompanyContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(m => m.Manager)
                 .WithMany(m => m.ManagerEmployees)
                 .HasForeignKey(em => em.ManagerId);
            });
        }
    }
}
