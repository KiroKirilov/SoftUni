using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Data.Config;
using MishMashWebApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.Data
{
    public class MishMashDbContext : DbContext
    {
        public MishMashDbContext()
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<UserChannel> UsersChannels { get; set; }

        public DbSet<ChannelTag> ChannelsTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(DbContextConfig.ConnectionString);
        }
    }
}
