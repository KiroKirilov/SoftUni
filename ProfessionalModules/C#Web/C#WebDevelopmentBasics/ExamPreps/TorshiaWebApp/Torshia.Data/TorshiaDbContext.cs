using Microsoft.EntityFrameworkCore;
using System;
using Torshia.Data.Config;
using Torshia.Models;

namespace Torshia.Data
{
    public class TorshiaDbContext : DbContext
    {
        public TorshiaDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TaskSector> TasksSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(DbContextConfig.ConnectionString);
        }
    }
}
